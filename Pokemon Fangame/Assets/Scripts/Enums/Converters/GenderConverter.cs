namespace Assets.Scripts.Enums.Converters
{
    public static class GenderConverter
    {
        private const string MALE = "M", FEMALE = "F";
        public static string GetGender(Gender gender)
        {
            switch (gender)
            {
                case Gender.MALE:
                    return MALE;
                case Gender.FEMALE:
                    return FEMALE;
                default:
                    throw new System.NotImplementedException();
            }
        }
    }
}
