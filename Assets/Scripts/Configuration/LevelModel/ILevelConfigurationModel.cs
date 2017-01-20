using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public interface ILevelConfigurationModel
    {
        int Index { get; }

        string LevelId { get; }

        List<ISheepConfiguration> SheepsOnLevel { get; }

        List<IDogConfiguration> DogsOnLevel { get; }

    }
}
