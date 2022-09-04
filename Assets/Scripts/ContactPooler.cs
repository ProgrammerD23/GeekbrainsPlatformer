using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class ContactPooler
    {
        private Collider2D _collider;
        private ContactPoint2D[] contact = new ContactPoint2D[5];
        private int contactCount = 0;
        private float treshold = 0.2f;

        public bool IsGrounded { get; private set; }
        public bool LeftContact { get; private set; }
        public bool RightContact { get; private set; }

        public ContactPooler(Collider2D collider)
        {
            _collider = collider;
        }

        public void Update()
        {
            IsGrounded = false;
            LeftContact = false;
            RightContact = false;

            contactCount = _collider.GetContacts(contact);

            for(int i = 0; i < contactCount; i++)
            {
                if (contact[i].normal.y > treshold) IsGrounded = true;
                if (contact[i].normal.x > treshold) LeftContact = true;
                if (contact[i].normal.x < - treshold) RightContact = true;
            }
        }
    }
}
