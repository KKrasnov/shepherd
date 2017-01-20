using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public interface IUIManager
    {
        void OnResolved();

        void Initialize();
        void Deinitialize();

        void UpdateUI(object model);
    }
}
