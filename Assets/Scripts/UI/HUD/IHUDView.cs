using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface IHUDView : IUIView
    {
        event Action OnPauseEvent;
    }
}
