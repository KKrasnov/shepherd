using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.LevelLoading
{
    public class SimpleLevelLoader : ILevelLoader
    {
        public SimpleLevelLoader()
        {
        }

        public void LoadLevel(string levelName, Action onComplete)
        {
            if (onComplete != null)
                onComplete();
        }
    }
}
