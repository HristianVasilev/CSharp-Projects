namespace Tests.Resources
{
    using Tests.Resources.ErrorMessagesResource;
    using System.Resources;

    public static class Resource
    {
        public static string GetString(string resourceName, Type resourceSource)
        {
            var resourceManager = new ResourceManager(resourceSource);
            return resourceManager.GetString(resourceName);
        }
    }
}
