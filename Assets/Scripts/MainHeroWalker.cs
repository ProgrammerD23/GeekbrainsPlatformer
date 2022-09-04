using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class MainHeroWalker
    {
        private float _walkSpeed = 200f;
        private float _animationsSpeed = 10f;
        private float _jumpForce = 8f;
        private float _movingThresh = 0.1f;
        private float _jumpThresh = 1f;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private float _yVelocity = 0;
        private float xVelocity = 0;
        private bool _isJump;
        private bool isMoving;
        private float xAxisInput;

        private LevelOfObject _view;
        private SpriteAnimatorController _playerAnimator;
        private AnimationConfig config;
        private ContactPooler contactPooler;

        private Transform playerT;
        private Rigidbody2D rigidbody;

        public MainHeroWalker(LevelOfObject view)
        {
            _view = view;
            playerT = _view.transform;
            rigidbody = view.rigidbody;

            config = Resources.Load<AnimationConfig>("AnimationRun");
            _playerAnimator = new SpriteAnimatorController(config);
            contactPooler = new ContactPooler(view.collider);
        }

        private void MoveTowards()
        {
            xVelocity = Time.fixedDeltaTime * _walkSpeed * (xAxisInput < 0 ? -1 : 1);
            rigidbody.velocity = new Vector2(xVelocity, _yVelocity);
            playerT.localScale = xAxisInput < 0 ? _leftScale : _rightScale;
        }

        public void Update()
        {
            _playerAnimator.Update();
            contactPooler.Update();
            xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            _yVelocity = rigidbody.velocity.y;

            isMoving = Mathf.Abs(xAxisInput) > _movingThresh;
            _playerAnimator.StartAnimation(_view.spriteRenderer, isMoving ? AnimState.Run : AnimState.Idle, true, _animationsSpeed);
            if (isMoving)
            {
                MoveTowards();
            }
            else
            {
                xVelocity = 0;
                rigidbody.velocity = new Vector2(xVelocity, rigidbody.velocity.y);
            }

            if (contactPooler.IsGrounded)
            {
                if(_isJump && _yVelocity <= _jumpThresh)
                {
                    rigidbody.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
                }
                else if(_yVelocity < 0)
                {
                    
                }
            }
            else
            {
                if(Mathf.Abs(_yVelocity) > _jumpThresh)
                {
                    _playerAnimator.StartAnimation(_view.spriteRenderer, AnimState.Jump, true, _animationsSpeed);
                }
            }
        }
    }
}
