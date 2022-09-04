using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class CannonControler
    {
        private Transform _muzzleT;
        private Transform _targerT;

        private Vector3 dir;
        private Vector3 axis;
        private float angle;

        public CannonControler(Transform muzzle, Transform target)
        {
            _muzzleT = muzzle;
            _targerT = target;
        }

        public void Update()
        {
            dir = _targerT.position - _muzzleT.position;
            angle = Vector3.Angle(Vector3.down, dir);
            axis = Vector3.Cross(Vector3.down, dir);

            _muzzleT.rotation = Quaternion.AngleAxis(angle, axis);
        }

    }
}
