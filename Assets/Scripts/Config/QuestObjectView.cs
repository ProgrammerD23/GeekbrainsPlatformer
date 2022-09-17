using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class QuestObjectView : LevelOfObject
    {
        public Color completedColor;
        public Color defaultColor;

        private void Awake()
        {
            defaultColor = spriteRenderer.color;
        }

        public void ProcessComplete()
        {
            spriteRenderer.color = completedColor;
        }

        public void ProcessActivate()
        {
            spriteRenderer.color = defaultColor;
        }
    }
}
