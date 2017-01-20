using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Input
{
    public class TouchInputService : IInputService
    {
        private readonly List<ITouchData> touches = new List<ITouchData>();

        public List<ITouchData> Touches
        {
            get
            {
                return touches;
            }
        }

        private bool isInputLocked = true;

        public bool IsInputLocked
        {
            get
            {
                return isInputLocked;
            }
            set
            {
                isInputLocked = value;
            }
        }

        public void Update()
        {
            touches.Clear();

            if (isInputLocked)
                return;

            foreach (var touch in UnityEngine.Input.touches)
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(touch.fingerId))
                    continue; 

                Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
                int mask = LayerMask.GetMask(new string[] { "Input" });
                RaycastHit2D hit = Physics2D.Raycast(worldPosition, worldPosition, 0, mask);

                touches.Add(new TouchData() { Touch = touch, Hit = hit });
            }
        }
    }
}
