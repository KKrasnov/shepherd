using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public class DogConfiguration : IDogConfiguration
    {
        private Vector2 initialPosition;

        public Vector2 InitialPosition
        {
            get
            {
                return initialPosition;
            }
        }

        public DogConfiguration(Vector2 initPos)
        {
            this.initialPosition = initPos;
        }
    }
}
