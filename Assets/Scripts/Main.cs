using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private InteractiveObjectView playerView;
        [SerializeField] private CannonView cannonView;

        private MainHeroWalker hero;
        private CannonControler cannonControler;
        private EmiterControler emiterControler;

        void Awake()
        {
            hero = new MainHeroWalker(playerView);
            cannonControler = new CannonControler(cannonView.muzzleT, playerView.transform);
            emiterControler = new EmiterControler(cannonView.bullets, cannonView.emiterT);
        }

        void Update()
        {
            hero.Update();
            cannonControler.Update();
            emiterControler.Update();
        }
    }
}
