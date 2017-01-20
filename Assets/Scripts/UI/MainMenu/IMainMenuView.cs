using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface IMainMenuView : IUIView
    {
        event Action OnStartEvent;
    }
}
