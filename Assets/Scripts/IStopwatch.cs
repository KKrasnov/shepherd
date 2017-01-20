using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        void Reset();

        int GetResultInSeconds();
    }
}
