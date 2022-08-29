using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public enum AnimState
    {
        Idle = 0,
        Run = 1,
        Jump = 2
    }

    [CreateAssetMenu(fileName = "SpriteAnimatorCfg", menuName = "Config / Animation", order = 1)]
    public class AnimationConfig : ScriptableObject
    {
        [Serializable]
        public class SpriteSeqence
        {
            public AnimState Track;
            public List<Sprite> Sprites = new List<Sprite>();
        }

        public List<SpriteSeqence> Sequences = new List<SpriteSeqence>();
    }
}
