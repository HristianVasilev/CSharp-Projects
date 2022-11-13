namespace Tests.Resources.ResourceKeys
{
    using R = ErrorMessagesResource;

    public static class ErrorMessages
    {
        public static string EnterValidEmail = "EnterValidEmail";
        public static string MaxEmailLength = "MaxEmailLength";

        public static string GetString(string resourceName)
        {
            return Resource.GetString(resourceName, typeof(R.ErrorMessages));
        }
    }
}
