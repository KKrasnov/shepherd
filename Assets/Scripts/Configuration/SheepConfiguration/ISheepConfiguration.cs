using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public interface ISheepConfiguration
    {
        Vector2 InitialPosition { get; }
    }
}