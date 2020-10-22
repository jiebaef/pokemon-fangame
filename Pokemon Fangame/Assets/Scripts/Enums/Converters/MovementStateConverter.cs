namespace Assets.Scripts.Enums.Converters
{
    public static class MovementStateConverter
    {
        private const string IDLING = "Idle", WALKING = "Walk", RUNNING = "Run", BIKING = "Bike", SURFING = "Surf";
        public static string GetState(MoveState moveState)
        {
            switch (moveState)
            {
                case MoveState.IDLING:
                    return IDLING;
                case MoveState.WALKING:
                    return WALKING;
                case MoveState.RUNNING:
                    return RUNNING;
                case MoveState.BIKING:
                    return BIKING;
                case MoveState.SURFING:
                    return SURFING;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
