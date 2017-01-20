using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public class GameplayInterfaceManager : IGameplayInterfaceManager
    {

        private readonly IHUDView hudView;
        private readonly IPauseMenuView pauseView;
        private readonly ILevelCompleteMenuView levelCompleteView;

        public event Action OnPauseEvent;
        public event Action OnUnpauseEvent;
        public event Action OnBackToMainEvent;
        public event Action OnLoadNextLevelEvent;

        public GameplayInterfaceManager(IHUDView hudView, IPauseMenuView pauseView, ILevelCompleteMenuView levelCompleteView)
        {
            if (hudView == null)
                throw new ArgumentNullException("hudView");

            this.hudView = hudView;

            if (pauseView == null)
                throw new ArgumentNullException("pauseView");

            this.pauseView = pauseView;

            if (levelCompleteView == null)
                throw new ArgumentNullException("levelCompleteView");

            this.levelCompleteView = levelCompleteView;
        }

        public void OnResolved()
        {
            hudView.SetVisible(false);
            pauseView.SetVisible(false);
            levelCompleteView.SetVisible(false);
        }

        public void Initialize()
        {
            hudView.OnPauseEvent += OnPauseHandler;
            pauseView.OnResumeEvent += OnUnpauseHandler;
            pauseView.OnBackToMainEvent += OnBackToMainHandler;
            levelCompleteView.OnBackToMainEvent += OnBackToMainHandler;
            levelCompleteView.OnNextLevelEvent += OnNextLevelHandler;

            hudView.SetVisible(true);
            levelCompleteView.SetVisible(false);
            pauseView.SetVisible(false);
        }

        public void Deinitialize()
        {
            hudView.OnPauseEvent -= OnPauseHandler;
            pauseView.OnResumeEvent -= OnUnpauseHandler;
            pauseView.OnBackToMainEvent -= OnBackToMainHandler;
            levelCompleteView.OnBackToMainEvent -= OnBackToMainHandler;
            levelCompleteView.OnNextLevelEvent -= OnNextLevelHandler;

            hudView.SetVisible(false);
            levelCompleteView.SetVisible(false);
            pauseView.SetVisible(false);
        }

        public void CompleteScreen()
        {
            hudView.SetVisible(false);
            levelCompleteView.SetVisible(true);
        }

        public void UpdateUI(object model)
        {
            hudView.ApplyView(model);
            levelCompleteView.ApplyView(model);
        }

        private void OnPauseHandler()
        {
            pauseView.SetVisible(true);
            if (OnPauseEvent != null)
                OnPauseEvent();
        }

        private void OnUnpauseHandler()
        {
            pauseView.SetVisible(false);
            if (OnUnpauseEvent != null)
                OnUnpauseEvent();
        }

        private void OnBackToMainHandler()
        {
            if (OnBackToMainEvent != null)
                OnBackToMainEvent();
        }

        private void OnNextLevelHandler()
        {
            if (OnLoadNextLevelEvent != null)
                OnLoadNextLevelEvent();
        }
    }
}
