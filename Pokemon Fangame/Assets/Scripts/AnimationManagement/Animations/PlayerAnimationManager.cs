using Assets.Scripts.AnimationManagement.AnimationNames;
using Assets.Scripts.AnimationManagement.Base_Classes;
using Assets.Scripts.Enums;

namespace Assets.Scripts.AnimationManagement.Animations
{
    public class PlayerAnimationManager : AnimationManagerBase
    {
        private PlayerAnimation PlayerAnimation;

        private PlayerMovementAnimationHandler PlayerMovementAnimationHandler;

        public PlayerAnimationManager(PlayerAnimation playerAnimation, PlayerMovementAnimationHandler playerMovementAnimationHandler)
        {
            PlayerAnimation = playerAnimation;
            PlayerMovementAnimationHandler = playerMovementAnimationHandler;
        }

        public void AnimateCharacter(bool isMoving, MoveState newMoveState, CharacterDirection characterFacingDirection)
        {
            if (isMoving)
            {
                PlayerMovementAnimationHandler.UpdateMovementState(newMoveState);
            }
            else
            {
                PlayerMovementAnimationHandler.UpdateMovementState(MoveState.IDLING);
            }

            ChangeAnimation(characterFacingDirection);
        }

        void ChangeAnimation(CharacterDirection characterFacingDirection)
        {
            switch (characterFacingDirection)
            {
                case CharacterDirection.UP:
                    PlayerAnimation.ChangeAnimationState(PlayerMovementAnimationHandler.UP);
                    break;
                case CharacterDirection.DOWN:
                    PlayerAnimation.ChangeAnimationState(PlayerMovementAnimationHandler.DOWN);
                    break;
                case CharacterDirection.LEFT:
                    PlayerAnimation.ChangeAnimationState(PlayerMovementAnimationHandler.LEFT);
                    break;
                case CharacterDirection.RIGHT:
                    PlayerAnimation.ChangeAnimationState(PlayerMovementAnimationHandler.RIGHT);
                    break;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
