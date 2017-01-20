using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Configuration
{
    public class SheepConfiguration : ISheepConfiguration
    {
        private Vector2 initialPosition;

        public Vector2 InitialPosition
        {
            get
            {
                return initialPosition;
            }
        }

        public SheepConfiguration(Vector2 initPos)
        {
            this.initialPosition = initPos;
        }
    }
}
