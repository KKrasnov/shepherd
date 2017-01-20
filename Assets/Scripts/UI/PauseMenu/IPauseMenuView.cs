using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface IPauseMenuView : IUIView
    {
        event Action OnResumeEvent;
        event Action OnBackToMainEvent;
    }
}
