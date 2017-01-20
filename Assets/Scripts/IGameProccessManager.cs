using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.Configuration;

namespace Shepherd
{
    public interface IGameProccessManager
    {
        IStopwatch Stopwatch { get; set; }

        event Action OnEndGameEvent;
        event Action OnNextLevelEvent;

        void OnResolved();

        void Initialize(ILevelConfigurationModel levelConfigurationModel);
        void Deinitialize();
        void Update();
    }
}
