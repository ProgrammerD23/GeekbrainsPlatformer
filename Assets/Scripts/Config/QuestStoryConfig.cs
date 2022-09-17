using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public enum StoryType
    {
        Common,
        Resettable
    }
    [CreateAssetMenu(fileName = "QuestStoryCongif", menuName = "Configs / QuestSystem / QuestStoryConfig", order = 1)]
    public class QuestStoryConfig : ScriptableObject
    {
        public QuestConfig[] questConfig;
        public QuestType type;
    }
}
