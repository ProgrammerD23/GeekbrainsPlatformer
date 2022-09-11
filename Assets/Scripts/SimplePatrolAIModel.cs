using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class SimplePatrolAIModel
    {
        private readonly AIConfig _config;
        private Transform _target;
        private int _currentPointIndex;

        public SimplePatrolAIModel(AIConfig config)
        {
            _config = config;
            _target = GetNextWaypoint();
        }

        public Vector2 CalculateVelocity(Vector2 fromPosition)
        {
            var sqrDistance = Vector2.SqrMagnitude((Vector2)_target.position - fromPosition);
            if (sqrDistance <= _config.minDistanceToTarget)
            {
                _target = GetNextWaypoint();
            }
            var direction = ((Vector2)_target.position - fromPosition).normalized;
            return _config.speedZone * direction;
        }
        private Transform GetNextWaypoint()
        {
            _currentPointIndex = (_currentPointIndex + 1) % _config.waypoints.Length;
            return _config.waypoints[_currentPointIndex];
        }

        public void Pursuit()
        {
            Debug.DrawRay(_config.enemyTransform.position, new Vector2(_target.position.x, _target.position.y + 3), Color.red);
            if (Physics2D.Raycast(_config.enemyTransform.position, new Vector2(_target.position.x, _target.position.y + 3)))
            {
                if (Vector2.Distance(_config.enemyTransform.position, _config.playerTransform.position) < 5)
                {
                    _config.enemyTransform.position = Vector2.MoveTowards(_config.enemyTransform.position, _config.playerTransform.position, _config.speed * Time.deltaTime);
                }
            }
        }
    }
}
