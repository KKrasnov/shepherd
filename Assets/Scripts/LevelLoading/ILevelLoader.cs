using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.LevelLoading
{
    public interface ILevelLoader
    {
        void LoadLevel(string levelName, Action onComplete);
    }
}
