using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.UI;
using Shepherd.LevelLoading;
using Shepherd.Configuration;

namespace Shepherd
{
    public class GameMain
    {
        private readonly IMainMenuInterfaceManager mainMenuInterfaceManager;
        private readonly IGameProccessManager gameProccessManager;
        private readonly ILevelLoader levelLoader;
        private readonly IConfigurationManager configurationManager;

        private ILevelConfigurationModel levelConfigurationModel;

        public GameMain(IMainMenuInterfaceManager mainMenuInterfaceManager, IGameProccessManager gameProccessManager, ILevelLoader levelLoader
            , IConfigurationManager configurationManager)
        {
            if (mainMenuInterfaceManager == null)
                throw new ArgumentNullException("mainMenuInterfaceManager");

            this.mainMenuInterfaceManager = mainMenuInterfaceManager;

            if (gameProccessManager == null)
                throw new ArgumentNullException("gameProccessManager");

            this.gameProccessManager = gameProccessManager;

            if (levelLoader == null)
                throw new ArgumentNullException("levelLoader");

            this.levelLoader = levelLoader;

            if (configurationManager == null)
                throw new ArgumentNullException("configurationManager");

            this.configurationManager = configurationManager;
        }

        public void OnResolved()
        {
            configurationManager.Load();

            gameProccessManager.OnResolved();

            mainMenuInterfaceManager.OnResolved();

            mainMenuInterfaceManager.OnStartGameEvent += OnStartGameHandler;

            gameProccessManager.OnEndGameEvent += OnEndGameHandler;
            gameProccessManager.OnNextLevelEvent += OnLoadNextLevelHandler;

            OnMainLevelLoaded();
        }

        public void Update()
        {
            mainMenuInterfaceManager.UpdateUI(null);
            gameProccessManager.Update();
        }

        private void OnStartGameHandler(int index)
        {
            mainMenuInterfaceManager.Deinitialize();
            levelConfigurationModel = configurationManager.GetGameConfigurationModel().Levels.Find(level => level.Index == index);
            levelLoader.LoadLevel(levelConfigurationModel.LevelId, OnGameLevelLoaded);
        }

        private void OnLoadNextLevelHandler()
        {
            gameProccessManager.Deinitialize();

            ILevelConfigurationModel oldLevelConfigurationModel = levelConfigurationModel;
            levelConfigurationModel = configurationManager.GetGameConfigurationModel().Levels.Find(level => level.Index == oldLevelConfigurationModel.Index + 1);

            if (levelConfigurationModel == null)
            {
                OnEndGameHandler();
                return;
            }

            levelLoader.LoadLevel(levelConfigurationModel.LevelId, OnGameLevelLoaded);
        }

        private void OnEndGameHandler()
        {
            gameProccessManager.Deinitialize();
            levelLoader.LoadLevel("Main", OnMainLevelLoaded);
        }

        private void OnGameLevelLoaded()
        {
            gameProccessManager.Initialize(levelConfigurationModel);
        }

        private void OnMainLevelLoaded()
        {
            mainMenuInterfaceManager.Initialize();
        }
    }
}
