using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public interface IPaddock : IEnvironmentObject
    {
        event Action<ISheep> OnSheepMovedInEvent;
    }
}
