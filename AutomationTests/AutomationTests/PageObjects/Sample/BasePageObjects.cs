namespace AutomationTests.PageObjects.Sample
{
    using AutomationTests.Utils.BaseComponents;
    using static AutomationTests.Constants.PageUrls;
    using EM = Constants.ExceptionMessages;

    public abstract class BasePageObjects : BaseComponent
    {
        public abstract string Url { get; }

        protected static string GetPageUrl(string sectionName, string key)
        {
            var section = Config.GetSection(UrlSection)?.GetSection(sectionName);

            if (section == null)
            {
                throw new ArgumentNullException(string.Format(EM.SectionValueIsNull, sectionName));
            }

            string? url = section.GetSection(key).Value;

            if (url == null)
            {
                throw new ArgumentNullException(string.Format(EM.SectionValueIsNull, key));
            }

            return url;
        }
    }
}
