using Assets.Scripts.AnimationManagement.Base_Classes;
using Assets.Scripts.Enums;
using Assets.Scripts.Enums.Converters;

namespace Assets.Scripts.AnimationManagement.AnimationNames
{
    public class PlayerMovementAnimationHandler : AnimationHandlerBase
    {
        private const string wordUp = "Up", wordDown = "Down", wordLeft = "Left", wordRight = "Right";

        public string UP { get; private set; }
        public string DOWN { get; private set; }
        public string LEFT { get; private set; }
        public string RIGHT { get; private set; }

        private string MovementState;

        private readonly string Gender;

        public PlayerMovementAnimationHandler(Gender gender, MoveState moveState, char delimiter = '_') : base(delimiter)
        {
            Gender = GenderConverter.GetGender(gender);

            UpdateMovementState(moveState);
        }

        public void UpdateMovementState(MoveState moveState)
        {
            MovementState = MovementStateConverter.GetState(moveState);

            UP = GetUp();
            DOWN = GetDown();
            RIGHT = GetRight();
            LEFT = GetLeft();
        }

        #region Helper methods
        
        private string GetUp() => GetPrefix() + wordUp;
        
        private string GetDown() => GetPrefix() + wordDown;
        
        private string GetLeft() => GetPrefix() + wordLeft;
        
        private string GetRight() => GetPrefix() + wordRight;

        private string GetPrefix() => Gender + Delimiter + MovementState + Delimiter;
        
        #endregion Helper methods
    }
}
