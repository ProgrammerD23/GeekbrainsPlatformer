using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    [Serializable]
    public struct AIConfig
    {
        public float speedZone;
        public float speed;
        public float minDistanceToTarget;
        public Transform[] waypoints;
        public Transform playerTransform;
        public Transform enemyTransform;
    }
}
