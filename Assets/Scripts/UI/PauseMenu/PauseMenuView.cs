using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Shepherd.UI
{
    public class PauseMenuView : MonoBehaviour, IPauseMenuView
    {
        [SerializeField]
        private Button resumeBtn = null;

        [SerializeField]
        private Button backToMainBtn = null;

        public event Action OnResumeEvent;
        public event Action OnBackToMainEvent;

        private void Awake()
        {
            resumeBtn.onClick.AddListener(new UnityAction(OnResumeBtnClick));
            backToMainBtn.onClick.AddListener(new UnityAction(OnBackToMainBtnClick));
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        public void ApplyView(object model)
        {
        }

        private void OnResumeBtnClick()
        {
            if (OnResumeEvent != null)
                OnResumeEvent();
        }

        private void OnBackToMainBtnClick()
        {
            if (OnBackToMainEvent != null)
                OnBackToMainEvent();
        }
    }
}
