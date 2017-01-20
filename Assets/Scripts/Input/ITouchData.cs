using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Input
{
    public interface ITouchData
    {
        Touch Touch { get; set; }

        RaycastHit2D Hit { get; set; }
    }
}
