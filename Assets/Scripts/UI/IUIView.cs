using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface IUIView
    {
        void SetVisible(bool visible);

        void ApplyView(object model);
    }
}
