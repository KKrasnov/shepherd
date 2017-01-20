using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public class DogFactory : MonoBehaviour, IDogFactory
    {

        [SerializeField]
        private GameObject _dogPrefab;

        public IDog CreateDog()
        {
            GameObject go = GameObject.Instantiate(_dogPrefab);
            return go.GetComponent<IDog>();
        }

        public void Destroy(IDog dog)
        {
            dog.Dispose();
        }
    }
}
