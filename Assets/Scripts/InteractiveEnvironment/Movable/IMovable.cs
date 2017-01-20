using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public interface IMovable : IEnvironmentObject
    {
        void SetDestination(Vector3 destination);
    }
}
