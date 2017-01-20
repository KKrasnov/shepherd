using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.Input;
using Shepherd.Configuration;
using Shepherd.Environment;
using Shepherd.LevelLoading;
using Shepherd.UI;

namespace Shepherd
{
    public class ApplicationEntry : MonoBehaviour
    {
        private GameMain gm;
        /// <summary>
        /// preffered application entry point
        /// </summary>
        void Awake()
        {
            IConfigurationManager configurationManager = new FakeConfigurationManager();

            IMainMenuView mainMenuView = GameObject.Find("MainMenu").GetComponent<IMainMenuView>();
            IHUDView hudView = GameObject.Find("HUD").GetComponent<IHUDView>();
            IPauseMenuView pauseView = GameObject.Find("PauseMenu").GetComponent<IPauseMenuView>();
            ILevelCompleteMenuView levelCompleteView = GameObject.Find("LevelCompleteMenu").GetComponent<ILevelCompleteMenuView>();

            IMainMenuInterfaceManager mainMenuInterfaceManager = new MainMenuInterfaceManager(mainMenuView);
            IGameplayInterfaceManager gameplayInterfaceManager = new GameplayInterfaceManager(hudView, pauseView, levelCompleteView);

            IDogFactory dogFactory = GameObject.Find("DogFactory").GetComponent<IDogFactory>();
            ISheepFactory sheepFactory = GameObject.Find("SheepFactory").GetComponent<ISheepFactory>();

            IPaddock paddock = GameObject.Find("Paddock").GetComponent<IPaddock>();

            IInputService inputService = new TouchInputService();//new MouseInputService();

            IGameField gameField = new GameField(dogFactory, sheepFactory, paddock);
            IGameProccessManager gameProccessManager = new GameProccessManager(inputService, gameplayInterfaceManager, gameField);
            ILevelLoader levelLoader = new SimpleLevelLoader();

            this.gm = new GameMain(mainMenuInterfaceManager, gameProccessManager, levelLoader, configurationManager);

            gm.OnResolved();
        }

        void Update()
        {
            gm.Update();
        }
    }
}
