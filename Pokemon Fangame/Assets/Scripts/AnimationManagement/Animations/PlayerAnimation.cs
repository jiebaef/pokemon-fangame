using Assets.Scripts.AnimationManagement.Base_Classes;
using UnityEngine;

namespace Assets.Scripts.AnimationManagement.Animations
{
    public class PlayerAnimation : AnimationBase
    {
        public PlayerAnimation(Animator animator) : base(animator) { }

        public override void ChangeAnimationState(string newState)
        {
            if (CurrentState == newState)
                return;

            Animator.Play(newState);

            CurrentState = newState;
        }
    }
}
