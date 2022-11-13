namespace QA_Probation.Steps
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ApplicationSteps : BaseSteps
    {
        private static string baseUrl = GetBaseUrl("ApplicationPage");

        public ApplicationSteps() : this(baseUrl)
        {
        }

        public ApplicationSteps(string baseUrl) : base(baseUrl)
        {
        }
    }
}
