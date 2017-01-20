using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Shepherd.UI
{
    public class LevelCompleteMenuView : MonoBehaviour, ILevelCompleteMenuView
    {
        [SerializeField]
        private Button nextLevelBtn = null;

        [SerializeField]
        private Button backToMainBtn = null;

        [SerializeField]
        private Text descriptionLbl = null;

        public event Action OnNextLevelEvent;
        public event Action OnBackToMainEvent;

        private void Awake()
        {
            nextLevelBtn.onClick.AddListener(new UnityAction(OnNextLevelBtnClick));
            backToMainBtn.onClick.AddListener(new UnityAction(OnBackToMainBtnClick));
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        public void ApplyView(object model)
        {
            int seconds = (int)model;
            descriptionLbl.text = string.Format("You have done this level in {0}:{1}{2}!", seconds / 60, seconds % 60 / 10, seconds % 10);
        }

        private void OnNextLevelBtnClick()
        {
            if (OnNextLevelEvent != null)
                OnNextLevelEvent();
        }

        private void OnBackToMainBtnClick()
        {
            if (OnBackToMainEvent != null)
                OnBackToMainEvent();
        }
    }
}
