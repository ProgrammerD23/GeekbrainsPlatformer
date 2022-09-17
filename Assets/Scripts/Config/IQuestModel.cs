using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GeekbrainsPlatformer
{
    public interface IQuestModel
    {
        bool TryComplet(GameObject actor);
    }
}
