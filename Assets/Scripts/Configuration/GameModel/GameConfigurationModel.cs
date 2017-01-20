using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public class GameConfigurationModel : IGameConfigurationModel
    {
        private List<ILevelConfigurationModel> levels = new List<ILevelConfigurationModel>();

        public List<ILevelConfigurationModel> Levels
        {
            get
            {
                return levels;
            }
        }
    }
}
