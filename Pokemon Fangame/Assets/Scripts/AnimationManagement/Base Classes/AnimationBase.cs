using UnityEngine;

namespace Assets.Scripts.AnimationManagement.Base_Classes
{
    public abstract class AnimationBase
    {
        protected Animator Animator { get; set; }

        protected string CurrentState { get; set; }

        protected AnimationBase(Animator animator)
        {
            Animator = animator;
        }

        public abstract void ChangeAnimationState(string newState);
    }
}