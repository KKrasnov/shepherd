using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Input
{
    public class MouseInputService : IInputService
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

            if (!UnityEngine.Input.GetMouseButton(0))
                return;

            if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                return;

            Touch touch = new Touch() { fingerId = 0, position = new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y) };

            Vector2 worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(touch.position.x, touch.position.y));
            int mask = LayerMask.GetMask(new string[] { "Input" });
            RaycastHit2D hit = Physics2D.Raycast(worldPosition, worldPosition, 0, mask);

            touches.Add(new TouchData()
            {
                Touch = new Touch() { fingerId = 0, position = new Vector2(UnityEngine.Input.mousePosition.x, UnityEngine.Input.mousePosition.y) },
                Hit = hit
            });
        }
    }
}
