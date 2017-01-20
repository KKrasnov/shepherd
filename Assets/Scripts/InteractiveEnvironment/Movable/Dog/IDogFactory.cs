using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public interface IDogFactory
    {
        IDog CreateDog();
        void Destroy(IDog dog);
    }
}
