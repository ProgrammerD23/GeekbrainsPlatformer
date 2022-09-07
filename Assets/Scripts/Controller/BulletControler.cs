using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class BulletControler
    {
        private Vector3 _velocity;
        private BulletView _view;

        public BulletControler(BulletView View)
        {
            _view = View;
            Active(false);
        }

        public void Active(bool val)
        {
            _view.gameObject.SetActive(val);
        }

        private void SetVelocity(Vector3 velocity)
        {
            _velocity = velocity;
            float angle = Vector3.Angle(Vector3.left, _velocity);
            Vector3 axis = Vector3.Cross(Vector3.left, _velocity);

            _view.transform.rotation = Quaternion.AngleAxis(angle, axis);
        }

        public void Trow(Vector3 position, Vector3 velocity)
        {
            _view.transform.position = position;
            SetVelocity(velocity);
            _view.rigidbody.velocity = Vector2.zero;
            _view.rigidbody.angularVelocity = 0;
            Active(true);

            _view.rigidbody.AddForce(velocity, ForceMode2D.Impulse);
        }
    }
}
