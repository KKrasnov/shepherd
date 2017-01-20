using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public class Paddock : MonoBehaviour, IPaddock
    {
        public event Action<ISheep> OnSheepMovedInEvent;

        public void SetPosition(Vector3 position)
        {
            transform.position = position;
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "sheep")
            {
                if (OnSheepMovedInEvent != null)
                    OnSheepMovedInEvent(other.GetComponent<ISheep>());
            }
        }
    }
}
