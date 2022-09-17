using System;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public class QuestController : IQuest
    {
        private InteractiveObjectView _player;

        private bool active;
        private IQuestModel _model;
        private QuestObjectView quest;

        public event EventHandler<IQuest> QuestCompleted;
        public bool IsCompleted { get; private set; }

        public QuestController(InteractiveObjectView player, IQuestModel model, QuestObjectView view)
        {
            _player = player;
            _model = model;
            active = false;
            quest = view;
        }

        public void OnContact(QuestObjectView QuestItem)
        {
            if(QuestItem != null)
            {
                if (_model.TryComplet(QuestItem.gameObject))
                {
                    if(QuestItem == quest)
                    {
                        Completed();
                    }
                }
            }
        }

        public void Completed()
        {
            if (!active) return;
            active = false;
            _player.OnQuestComplete -= OnContact;
            quest.ProcessComplete();
            QuestCompleted?.Invoke(this, this);
        }

        public void Reset()
        {
            if (active) return;
            active = true;
            _player.OnQuestComplete += OnContact;
            quest.ProcessActivate();
        }

        public void Dispose()
        {
            _player.OnQuestComplete -= OnContact;
        }
    }
}
