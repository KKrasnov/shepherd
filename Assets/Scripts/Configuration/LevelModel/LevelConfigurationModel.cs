using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public class LevelConfigurationModel : ILevelConfigurationModel
    {
        private int index;

        public int Index
        {
            get
            {
                return index;
            }
        }

        private string levelId;

        public string LevelId
        {
            get
            {
                return levelId;
            }
        }

        private List<ISheepConfiguration> sheepsOnLevel = new List<ISheepConfiguration>();

        public List<ISheepConfiguration> SheepsOnLevel
        {
            get
            {
                return sheepsOnLevel;
            }
        }

        private List<IDogConfiguration> dogsOnLevel = new List<IDogConfiguration>();

        public List<IDogConfiguration> DogsOnLevel
        {
            get
            {
                return dogsOnLevel;
            }
        }

        public LevelConfigurationModel(int index, string levelId)
        {
            this.index = index;
            this.levelId = levelId;
        }
    }
}
