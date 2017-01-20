using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public interface IGameConfigurationModel
    {
        List<ILevelConfigurationModel> Levels { get; }
    }
}