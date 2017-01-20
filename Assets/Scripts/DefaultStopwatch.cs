using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace Shepherd
{
    public class DefaultStopwatch : IStopwatch
    {
        private Stopwatch stopwatch;

        public DefaultStopwatch()
        {
            stopwatch = new Stopwatch();
        }

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public void Reset()
        {
            stopwatch.Reset();
        }

        public int GetResultInSeconds()
        {
            return (int)stopwatch.Elapsed.TotalSeconds;
        }
    }
}
