using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class EmiterControler
    {
        private List<BulletControler> bulletControlers = new List<BulletControler>();
        private Transform transform;

        private int index;
        private float timeTillNextBull;
        private float startSpeed = 15f;
        private float delay = 1;

        public EmiterControler(List<BulletView> bulletViews, Transform emiterTransform)
        {
            transform = emiterTransform;
            foreach(BulletView bulletView in bulletViews)
            {
                bulletControlers.Add(new BulletControler(bulletView));
            }
        }

        public void Update()
        {
            if(timeTillNextBull > 0)
            {
                bulletControlers[index].Active(false);
                timeTillNextBull -= Time.deltaTime;
            }
            else
            {
                timeTillNextBull = delay;
                bulletControlers[index].Trow(transform.position, -transform.up * startSpeed);
                index++;
                if(index >= bulletControlers.Count)
                {
                    index = 0;
                }
            }
        }
    }
}
