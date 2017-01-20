using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Animation
{
    public abstract class BaseAnimationController : MonoBehaviour
    {
        public abstract void PlayAnimation(string animationName);
    }
}
