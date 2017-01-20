using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Shepherd.UI
{
    public class HUDView : MonoBehaviour, IHUDView
    {

        [SerializeField]
        private Button pauseBtn = null;

        [SerializeField]
        private Text timerLbl = null;

        public event Action OnPauseEvent;

        private void Awake()
        {
            pauseBtn.onClick.AddListener(new UnityAction(OnPauseBtnClick));
        }

        public void SetVisible(bool visible)
        {
            gameObject.SetActive(visible);
        }

        public void ApplyView(object model)
        {
            int seconds = (int)model;
            timerLbl.text = string.Format("{0}:{1}{2}", seconds / 60, seconds % 60 / 10, seconds % 10);
        }

        private void OnPauseBtnClick()
        {
            if (OnPauseEvent != null)
                OnPauseEvent();
        }
    }
}
