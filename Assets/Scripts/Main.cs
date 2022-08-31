using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelOfObject playerView;
        private MainHeroWalker hero;

        void Awake()
        {
            hero = new MainHeroWalker(playerView);
        }

        void Update()
        {
            hero.Update();
        }
    }
}
