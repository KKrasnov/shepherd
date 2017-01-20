using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public class SheepFactory : MonoBehaviour, ISheepFactory
    {
        [SerializeField]
        private GameObject _dogPrefab;

        public ISheep CreateSheep()
        {
            GameObject go = GameObject.Instantiate(_dogPrefab);
            return go.GetComponent<ISheep>();
        }

        public void Destroy(ISheep sheep)
        {
            sheep.Dispose();
        }
    }
}
