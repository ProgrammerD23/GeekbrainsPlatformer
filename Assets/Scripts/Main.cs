using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private InteractiveObjectView playerView;
        [SerializeField] private CannonView cannonView;
        [SerializeField] private GenerateLevelView _generateLevelView;

        private MainHeroWalker hero;
        private CannonControler cannonControler;
        private EmiterControler emiterControler;
        private GeneratorLevelController _generatorLevelController;

        void Awake()
        {
            hero = new MainHeroWalker(playerView);
            cannonControler = new CannonControler(cannonView.muzzleT, playerView.transform);
            emiterControler = new EmiterControler(cannonView.bullets, cannonView.emiterT);
            _generatorLevelController = new GeneratorLevelController(_generateLevelView);
            _generatorLevelController.Awake();
        }

        void Update()
        {
            hero.Update();
            cannonControler.Update();
            emiterControler.Update();
        }
    }
}
