using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public interface ISheep : IMovable
    {
        bool IsAlreadyAssignedToLeader { get; set; }
        bool IsDelivered { get; set; }
    }
}
