using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Input
{
    public interface IInputService
    {
        bool IsInputLocked { get; set; }

        List<ITouchData> Touches { get; }

        void Update();
    }
}