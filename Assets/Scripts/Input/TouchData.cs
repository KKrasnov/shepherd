using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Input
{
    public class TouchData : ITouchData
    {
        public Touch Touch { get; set; }

        public RaycastHit2D Hit { get; set; }
    }
}
