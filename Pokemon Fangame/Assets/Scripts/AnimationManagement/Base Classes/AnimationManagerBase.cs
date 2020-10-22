namespace Assets.Scripts.AnimationManagement.Base_Classes
{
    public abstract class AnimationManagerBase
    {
        protected AnimationBase ObjectAnimation { get; private set; }

        protected AnimationHandlerBase ObjectAnimationHandler { get; private set; }

        protected AnimationManagerBase()
        {

        }

        protected AnimationManagerBase(AnimationBase animationBase, AnimationHandlerBase animationHandlerBase)
        {
            ObjectAnimation = animationBase;
            ObjectAnimationHandler = animationHandlerBase;
        }


    }
}