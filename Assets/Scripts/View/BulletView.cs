using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class BulletView : LevelOfObject
    {
        private int damagePoint = 10;
        public int DamagePoint { get => damagePoint; set => damagePoint = value; }
    }
}
