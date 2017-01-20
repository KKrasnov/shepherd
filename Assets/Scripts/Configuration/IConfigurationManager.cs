using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public interface IConfigurationManager
    {
        void Load();

        IGameConfigurationModel GetGameConfigurationModel();
    }
}
