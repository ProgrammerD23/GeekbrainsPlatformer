using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelOfObject playerView;
        private AnimationConfig config;
        private SpriteAnimatorController playerAnimator;

        void Awake()
        {
            config = Resources.Load<AnimationConfig>("AnimationRun");
            playerAnimator = new SpriteAnimatorController(config);
            playerAnimator.StartAnimation(playerView.spriteRenderer, AnimState.Run, true, 30f);
        }

        void Update()
        {
            playerAnimator.Update();
        }
    }
}
