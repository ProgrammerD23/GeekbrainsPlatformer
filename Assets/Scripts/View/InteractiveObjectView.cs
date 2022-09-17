using System;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class InteractiveObjectView : LevelOfObject
    {
        public Action<BulletView> TakeDamage { get; set; }
        public Action<QuestObjectView> OnQuestComplete { get; set; }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent(out LevelOfObject contactView))
            {
                if(contactView is QuestObjectView)
                {
                    OnQuestComplete?.Invoke((QuestObjectView)contactView);
                }
                if (contactView is BulletView)
                {
                    TakeDamage?.Invoke((BulletView)contactView);
                }
            }
        }
    }
}
