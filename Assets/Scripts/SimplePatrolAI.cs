using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class SimplePatrolAI
    {
        private readonly LevelOfObject _view;
        private readonly SimplePatrolAIModel _model;

        public SimplePatrolAI(LevelOfObject view, SimplePatrolAIModel model)
        {
            _view = view != null ? view : throw new  ArgumentNullException(nameof(view));
            _model = model != null ? model : throw new ArgumentNullException(nameof(model));
        }
        public void FixedUpdate()
        {
            var newVelocity = _model.CalculateVelocity(_view.transform.position) * Time.fixedDeltaTime;
            _view.rigidbody.velocity = newVelocity;
        }
        public void Update()
        {
            _model.Pursuit();
        }
    }
}
