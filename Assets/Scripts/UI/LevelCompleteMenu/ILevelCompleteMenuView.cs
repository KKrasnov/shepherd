using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface ILevelCompleteMenuView : IUIView
    {
        event Action OnNextLevelEvent;
        event Action OnBackToMainEvent;
    }
}
