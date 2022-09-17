using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class QuestCoinModel : IQuestModel
    {
        public bool TryComplet(GameObject actor)
        {
            return actor.CompareTag("QuestCoin");
        }
    }
}
