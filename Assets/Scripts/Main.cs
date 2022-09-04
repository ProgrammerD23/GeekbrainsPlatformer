using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private LevelOfObject playerView;
        [SerializeField] private CannonView cannonView;

        private MainHeroWalker hero;
        private CannonControler cannonControler;

        void Awake()
        {
            hero = new MainHeroWalker(playerView);
            cannonControler = new CannonControler(cannonView.muzzleT, playerView.transform);
        }

        void Update()
        {
            hero.Update();
            cannonControler.Update();
        }
    }
}
