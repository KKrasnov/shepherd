using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.UI
{
    public class MainMenuInterfaceManager : IMainMenuInterfaceManager
    {
        private readonly IMainMenuView mainMenuView;

        public event Action<int> OnStartGameEvent;

        public MainMenuInterfaceManager(IMainMenuView mainMenuView)
        {
            if (mainMenuView == null)
                throw new ArgumentNullException("mainMenuView");

            this.mainMenuView = mainMenuView;
        }

        public void OnResolved()
        {
            mainMenuView.SetVisible(false);
        }

        public void Initialize()
        {
            mainMenuView.OnStartEvent += OnStartHandler;

            mainMenuView.SetVisible(true);
        }

        public void Deinitialize()
        {
            mainMenuView.OnStartEvent -= OnStartHandler;

            mainMenuView.SetVisible(false);
        }

        public void UpdateUI(object model)
        {
        }

        private void OnStartHandler()
        {
            if (OnStartGameEvent != null)
                OnStartGameEvent(0);
        }
    }
}
