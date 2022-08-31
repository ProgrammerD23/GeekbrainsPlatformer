using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class MainHeroWalker
    {
        private float _walkSpeed = 3f;
        private float _animationsSpeed = 10f;
        private float _jumpForce = 8f;
        private float _movingThresh = 0.1f;
        private float _jumpThresh = 1f;
        private float _groundLevel = 0.5f;
        private float _g = -10f;
        private Vector3 _leftScale = new Vector3(-1, 1, 1);
        private Vector3 _rightScale = new Vector3(1, 1, 1);
        private float _yVelocity = 0;
        private bool _isJump;
        private bool isMoving;
        private float xAxisInput;

        private LevelOfObject _view;
        private SpriteAnimatorController _playerAnimator;
        private AnimationConfig config;

        private Transform playerT;
        public MainHeroWalker(LevelOfObject view)
        {
            _view = view;
            playerT = _view.transform;
            config = Resources.Load<AnimationConfig>("AnimationRun");
            _playerAnimator = new SpriteAnimatorController(config);
        }

        private void MoveTowards()
        {
            playerT.position += Vector3.right * (Time.deltaTime * _walkSpeed * (xAxisInput < 0 ? -1 : 1));
            playerT.localScale = xAxisInput < 0 ? _leftScale : _rightScale;
        }

        private bool IsGrounded()
        {
            return playerT.position.y <= _groundLevel && _yVelocity <= 0;
        }

        public void Update()
        {
            _playerAnimator.Update();
            xAxisInput = Input.GetAxis("Horizontal");
            _isJump = Input.GetAxis("Vertical") > 0;
            isMoving = Mathf.Abs(xAxisInput) > _movingThresh;
            if (isMoving)
            {
                MoveTowards();
            }
            _playerAnimator.StartAnimation(_view.spriteRenderer, isMoving ? AnimState.Run : AnimState.Idle, true, _animationsSpeed);

            if (IsGrounded())
            {
                if(_isJump && _yVelocity == 0)
                {
                    _yVelocity = _jumpForce;
                }
                else if(_yVelocity < 0)
                {
                    _yVelocity = 0;
                    playerT.position = new Vector3(playerT.position.x, _groundLevel, playerT.position.z);
                }
            }
            else
            {
                if(Mathf.Abs(_yVelocity) > _jumpThresh)
                {
                    _playerAnimator.StartAnimation(_view.spriteRenderer, AnimState.Jump, true, _animationsSpeed);
                }
                _yVelocity += _g * Time.deltaTime;
                playerT.position += Vector3.up * (Time.deltaTime * _yVelocity);
            }
        }
    }
}
