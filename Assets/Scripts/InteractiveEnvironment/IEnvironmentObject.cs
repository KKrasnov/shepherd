using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public interface IEnvironmentObject : IDisposable
    {
        void SetActive(bool active);
        void SetParent(Transform newParent);
        void SetPosition(Vector3 position);
    }
}
