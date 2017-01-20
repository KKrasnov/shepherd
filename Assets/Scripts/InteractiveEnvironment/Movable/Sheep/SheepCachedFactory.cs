using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Environment
{
    public class SheepCachedFactory : MonoBehaviour, ISheepFactory
    {
        [SerializeField]
        private int cachedObjectsLimit = 3;

        [SerializeField]
        private Transform cacheContainer = null;

        [SerializeField]
        private GameObject factoryObject = null;

        private ISheepFactory factory;

        private List<ISheep> cachedObejcts = new List<ISheep>();

        private void Awake()
        {
            factory = factoryObject.GetComponent<ISheepFactory>();
        }

        public ISheep CreateSheep()
        {
            ISheep sheep = null;
            if (cachedObejcts.Count > 0)
            {
                sheep = cachedObejcts[0];
                cachedObejcts.RemoveAt(0);
                sheep.SetActive(true);
                sheep.SetParent(null);
            }
            else
                sheep = factory.CreateSheep();
            return sheep;
        }

        public void Destroy(ISheep sheep)
        {
            if (cachedObejcts.Count >= cachedObjectsLimit)
                factory.Destroy(sheep);
            else
            {
                cachedObejcts.Add(sheep);
                sheep.SetParent(cacheContainer);
                sheep.SetActive(false);
            }
        }
    }
}
