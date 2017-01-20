using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public class FakeConfigurationManager : IConfigurationManager
    {
        private IGameConfigurationModel gameConfigurationModel;

        public FakeConfigurationManager()
        {
        }

        public void Load()
        {
            gameConfigurationModel = new GameConfigurationModel();
            ILevelConfigurationModel levelConfig = new LevelConfigurationModel(0, "Game");

            levelConfig.DogsOnLevel.Add(new DogConfiguration(new Vector2(0, 0)));
            levelConfig.DogsOnLevel.Add(new DogConfiguration(new Vector2(-5, -3)));
            //levelConfig.DogsOnLevel.Add(new DogConfiguration(new Vector2(-5, 3)));

            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(5, 0)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(6, -1)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(7, -2)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(6, -5)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(8, 5)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(9, 3)));

            gameConfigurationModel.Levels.Add(levelConfig);

            levelConfig = new LevelConfigurationModel(1, "Game");

            levelConfig.DogsOnLevel.Add(new DogConfiguration(new Vector2(0, 0)));
            levelConfig.DogsOnLevel.Add(new DogConfiguration(new Vector2(-5, -3)));
            levelConfig.DogsOnLevel.Add(new DogConfiguration(new Vector2(-5, 3)));

            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-5, 0)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(6, -3)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(7, -2)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(6, -5)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(8, 5)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(8, 3)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(8, 1)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(9, 3)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-6, -3)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-7, -2)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-6, -5)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-8, 5)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-8, 3)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-8, 1)));
            levelConfig.SheepsOnLevel.Add(new SheepConfiguration(new Vector2(-9, 3)));

            gameConfigurationModel.Levels.Add(levelConfig);
        }

        public IGameConfigurationModel GetGameConfigurationModel()
        {
            return gameConfigurationModel;
        }
    }
}
