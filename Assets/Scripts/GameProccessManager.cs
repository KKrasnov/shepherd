using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.Input;
using Shepherd.UI;
using Shepherd.Configuration;
using Shepherd.Environment;

namespace Shepherd
{
    public class GameProccessManager : IGameProccessManager
    {
        private readonly IInputService inputService;
        private readonly IGameplayInterfaceManager gameplayInterfaceManager;
        private readonly IGameField gameField;

        private IStopwatch stopwatch;
        public IStopwatch Stopwatch
        {
            get
            {
                if (stopwatch == null)
                {
                    stopwatch = new DefaultStopwatch();
                }
                return stopwatch;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
                if (stopwatch != null)
                    throw new InvalidOperationException();
                stopwatch = value;
            }
        }

        private IDog currentDog;

        private bool isActive = false;

        public event Action OnEndGameEvent;
        public event Action OnNextLevelEvent;

        public GameProccessManager(IInputService inputService, IGameplayInterfaceManager gameplayInterfaceManager, IGameField gameField)
        {
            if (inputService == null)
                throw new ArgumentNullException("inputService");

            this.inputService = inputService;

            if (gameplayInterfaceManager == null)
                throw new ArgumentNullException("gameplayInterfaceManager");

            this.gameplayInterfaceManager = gameplayInterfaceManager;

            if (gameField == null)
                throw new ArgumentNullException("gameField");

            this.gameField = gameField;
        }

        public void OnResolved()
        {
            gameplayInterfaceManager.OnResolved();

            gameplayInterfaceManager.OnPauseEvent += OnPauseHandler;
            gameplayInterfaceManager.OnUnpauseEvent += OnUnpauseHandler;
            gameplayInterfaceManager.OnLoadNextLevelEvent += OnNextLevelHandler;
            gameplayInterfaceManager.OnBackToMainEvent += OnBackToMainHandler;
        }

        public void Initialize(ILevelConfigurationModel levelConfigurationModel)
        {
            gameField.SetupEnvironment(levelConfigurationModel);

            gameplayInterfaceManager.Initialize();

            inputService.IsInputLocked = false;

            Stopwatch.Reset();
            Stopwatch.Start();

            isActive = true;
        }

        public void Deinitialize()
        {
            inputService.IsInputLocked = true;

            PauseGame(false);
            currentDog = null;

            gameField.ResetEnvironment();

            gameplayInterfaceManager.Deinitialize();

            Stopwatch.Stop();

            isActive = false;
        }

        public void Update()
        {
            if (!isActive) return;

            UpdateInput();
            CheckWin();

            gameplayInterfaceManager.UpdateUI(Stopwatch.GetResultInSeconds());
        }

        private void UpdateInput()
        {
            inputService.Update();
            foreach (ITouchData touchData in inputService.Touches)
            {
                if (touchData.Hit.transform == null)
                {
                    ApplyNewDestination(new Vector3(touchData.Touch.position.x, touchData.Touch.position.y));
                    continue;
                }

                if (touchData.Hit.transform.gameObject.tag == "dog")
                {
                    currentDog = touchData.Hit.transform.gameObject.GetComponent<IDog>();
                }
                else ApplyNewDestination(new Vector3(touchData.Touch.position.x, touchData.Touch.position.y));
            }
        }

        private void ApplyNewDestination(Vector2 touchPos)
        {
            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(touchPos);

            if (currentDog != null)
                currentDog.SetDestination(worldPosition);
        }

        private void OnPauseHandler()
        {
            PauseGame(true);
        }

        private void OnUnpauseHandler()
        {
            PauseGame(false);
        }

        private void OnNextLevelHandler()
        {
            if (OnNextLevelEvent != null)
                OnNextLevelEvent();
        }

        private void OnBackToMainHandler()
        {
            if (OnEndGameEvent != null)
                OnEndGameEvent();
        }

        private void PauseGame(bool pause)
        {
            if (pause)
            {
                Stopwatch.Stop();
            }
            else
            {
                Stopwatch.Start();
            }
            Time.timeScale = pause ? 0 : 1;
        }

        private void CheckWin()
        {
            if (!gameField.IsAllSheepsWasDelivered())
                return;
            Stopwatch.Stop();
            gameplayInterfaceManager.CompleteScreen();
        }
    }
}
