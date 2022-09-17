using System;
using System.Collections.Generic;
using UnityEngine;

public interface IQuestStoryModel : IDisposable
{
    bool IsDone { get; }
}
