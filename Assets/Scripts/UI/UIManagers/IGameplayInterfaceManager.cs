using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface IGameplayInterfaceManager : IUIManager
    {
        event Action OnPauseEvent;
        event Action OnUnpauseEvent;
        event Action OnBackToMainEvent;
        event Action OnLoadNextLevelEvent;

        void CompleteScreen();
    }
}
