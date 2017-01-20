using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Shepherd.Animation;

namespace Shepherd.Environment
{
    public class Sheep : MonoBehaviour, ISheep
    {

        [SerializeField]
        private float speed = 5;

        [SerializeField]
        private BaseAnimationController animationController = null;

        private Vector3 destination;

        private bool isAssignedToLeader = false;

        public bool IsAlreadyAssignedToLeader
        {
            get
            {
                return isAssignedToLeader;
            }
            set
            {
                isAssignedToLeader = value;
            }
        }

        private bool isDelivered = false;

        public bool IsDelivered
        {
            get
            {
                return isDelivered;
            }
            set
            {
                isDelivered = value;
            }
        }

        public void SetPosition(Vector3 position)
        {
            transform.position = this.destination = position;
        }

        public void SetDestination(Vector3 destination)
        {
            this.destination = destination;
        }

        public void SetActive(bool active)
        {
            gameObject.SetActive(active);
        }

        public void SetParent(Transform newParent)
        {
            transform.parent = newParent;
        }

        public void Dispose()
        {
            GameObject.Destroy(this.gameObject);
        }

        private void Update()
        {
            UpdateAnimation(MoveTo(destination));
        }

        private void OnDisable()
        {
            IsAlreadyAssignedToLeader = false;
            isDelivered = false;
        }

        private Vector3 MoveTo(Vector3 destination)
        {
            if (Vector3.Distance(destination, this.transform.position) < 0.1f) return Vector3.zero;
            Vector3 direction = (destination - this.transform.position).normalized;

            Vector3 moveAmount = direction * Time.deltaTime * speed;

            transform.Translate(moveAmount);
            return moveAmount;
        }

        private void UpdateAnimation(Vector3 moveAmount)
        {
            if (moveAmount == Vector3.zero)
            {
                animationController.PlayAnimation("idle");
            }
            else if (Mathf.Abs(moveAmount.x) > Mathf.Abs(moveAmount.y))
            {
                if (moveAmount.x < 0)
                {
                    animationController.PlayAnimation("move_left");
                }
                else
                {
                    animationController.PlayAnimation("move_right");
                }
            }
            else
            {
                if (moveAmount.y < 0)
                {
                    animationController.PlayAnimation("move_forward");
                }
                else
                {
                    animationController.PlayAnimation("move_backward");
                }
            }
        }
    }
}
