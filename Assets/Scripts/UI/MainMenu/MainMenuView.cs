using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Shepherd.UI
{
    public class MainMenuView : MonoBehaviour, IMainMenuView
    {
        [SerializeField]
        private Button startGameBtn = null;

        public event Action OnStartEvent;

        private void Awake()
        {
            startGameBtn.onClick.AddListener(new UnityAction(OnBtnStartClick));
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        public void ApplyView(object model)
        {
        }

        private void OnBtnStartClick()
        {
            if (OnStartEvent != null)
                OnStartEvent();
        }
    }
}
