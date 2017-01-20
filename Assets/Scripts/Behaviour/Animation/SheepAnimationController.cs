using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shepherd.Animation
{
    public class SheepAnimationController : BaseAnimationController
    {
        [SerializeField]
        private Animator mecanimAnimator = null;

        private string currentAnimation = string.Empty;

        public override void PlayAnimation(string animationName)
        {
            if (currentAnimation != string.Empty)
                mecanimAnimator.ResetTrigger(currentAnimation);
            mecanimAnimator.SetTrigger(animationName);
            currentAnimation = animationName;
        }
    }
}
