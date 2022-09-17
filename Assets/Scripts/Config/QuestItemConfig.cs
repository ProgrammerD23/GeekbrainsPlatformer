using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    [CreateAssetMenu(fileName = "QuestItemCongif", menuName = "Configs / QuestSystem / QuestItemConfig", order = 1)]
    public class QuestItemConfig : ScriptableObject
    {
        public int questId;
        public List<int> questItemId;
    }
}
