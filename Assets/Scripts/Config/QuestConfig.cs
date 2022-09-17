using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public enum QuestType
    {
        Coins,
        Buttons
    }
    [CreateAssetMenu(fileName = "QuestCongif", menuName = "Configs / QuestSystem / QuestConfig", order = 1)]
    public class QuestConfig : ScriptableObject
    {
        public int id;
        public QuestType type;
    }
}
