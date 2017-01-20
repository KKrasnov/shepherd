using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public class DogCachedFactory : MonoBehaviour, IDogFactory
    {

        [SerializeField]
        private int cachedObjectsLimit = 3;

        [SerializeField]
        private Transform cacheContainer = null;

        [SerializeField]
        private GameObject factoryObject = null;

        private IDogFactory factory;

        private List<IDog> cachedObejcts = new List<IDog>();

        private void Awake()
        {
            factory = factoryObject.GetComponent<IDogFactory>();
        }

        public IDog CreateDog()
        {
            IDog dog = null;
            if (cachedObejcts.Count > 0)
            {
                dog = cachedObejcts[0];
                cachedObejcts.RemoveAt(0);
                dog.SetActive(true);
                dog.SetParent(null);
            }
            else
                dog = factory.CreateDog();
            return dog;
        }

        public void Destroy(IDog dog)
        {
            if (cachedObejcts.Count >= cachedObjectsLimit)
                factory.Destroy(dog);
            else
            {
                cachedObejcts.Add(dog);
                dog.SetParent(cacheContainer);
                dog.SetActive(false);
            }
        }
    }
}
