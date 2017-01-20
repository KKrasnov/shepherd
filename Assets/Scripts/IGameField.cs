using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.Configuration;

namespace Shepherd
{
    public interface IGameField
    {
        void SetupEnvironment(ILevelConfigurationModel levelConfigurationModel);
        void ResetEnvironment();

        bool IsAllSheepsWasDelivered();
    }
}
