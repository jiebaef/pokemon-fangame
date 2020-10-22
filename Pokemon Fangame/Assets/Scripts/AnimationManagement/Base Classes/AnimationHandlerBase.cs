namespace Assets.Scripts.AnimationManagement.Base_Classes
{
    public abstract class AnimationHandlerBase
    {
        protected char Delimiter;

        protected AnimationHandlerBase(char delimiter = '_') 
        {
            Delimiter = delimiter;
        }
    }
}
