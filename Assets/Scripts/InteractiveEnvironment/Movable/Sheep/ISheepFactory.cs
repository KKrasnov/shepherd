using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public interface ISheepFactory
    {
        ISheep CreateSheep();
        void Destroy(ISheep sheep);
    }
}
