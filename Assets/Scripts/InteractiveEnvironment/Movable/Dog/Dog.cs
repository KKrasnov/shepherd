using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public class Dog : MonoBehaviour, IDog
    {
        [SerializeField]
        private float speed = 5;

        [SerializeField]
        private TriggerHandler2D leadershipAreaTriggerHandler = null;

        private Vector3 destination;

        private List<ISheep> sheepsUnderControl = new List<ISheep>();

        private void Awake()
        {
            leadershipAreaTriggerHandler.OnTriggerEnter2DEvent += OnLeaderShipAreaTriggerEnter;
        }

        public void Update()
        {
            MoveTo(destination);

            for (int i = sheepsUnderControl.Count - 1; i >= 0; i--)
            {
                ISheep sheep = sheepsUnderControl[i];
                if (sheep.IsDelivered)
                {
                    sheep.IsAlreadyAssignedToLeader = false;
                    sheepsUnderControl.RemoveAt(i);
                    continue;
                }
                sheep.SetDestination(transform.position);
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

        private void MoveTo(Vector3 destination)
        {
            if (Vector3.Distance(destination, new Vector3(transform.position.x, transform.position.y)) < 0.1f) return;
            Vector3 direction = (destination - new Vector3(transform.position.x, transform.position.y)).normalized;
            transform.Translate(direction * Time.deltaTime * speed);
        }

        private void OnLeaderShipAreaTriggerEnter(Collider2D other)
        {
            if (other.gameObject.tag == "sheep")
            {
                ISheep sheep = other.GetComponent<ISheep>();
                if (sheep.IsAlreadyAssignedToLeader || sheep.IsDelivered)
                    return;
                sheep.IsAlreadyAssignedToLeader = true;
                sheepsUnderControl.Add(sheep);
            }
        }
    }
}
