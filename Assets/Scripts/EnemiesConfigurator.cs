using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class EnemiesConfigurator : MonoBehaviour
    {
        [SerializeField] private AIConfig _simplePatrolAIConfig;
        [SerializeField] private LevelOfObject _simplePatrolAIView;
        private SimplePatrolAI _simplePatrolAI;

        private void Start()
        {
            _simplePatrolAI = new SimplePatrolAI(_simplePatrolAIView, new
            SimplePatrolAIModel(_simplePatrolAIConfig));
        }

        private void Update()
        {
            _simplePatrolAI.Update();
        }

        private void FixedUpdate()
        {
            if (_simplePatrolAI != null) _simplePatrolAI.FixedUpdate();
        }
    }
}
