using System.Collections.Generic;

namespace AadGraphApiHelper
{
    internal class AadEnvironmentSet : List<AadEnvironment>
    {
        private static readonly IList<string> aadGraphApiVersions = new[] { @"1.6", @"1.61", @"beta" };

        private static readonly IList<string> msGraphApiVersions = new[] { @"v1.0", @"beta" };

        public AadEnvironmentSet()
        {
            this.Add(MSGraphProduction);
            this.Add(AadGraphProduction);
            this.Add(MSGraphPreProduction);
            this.Add(AadGraphPreProduction);
        }


        public static AadEnvironment AadGraphProduction
        {
            get
            {
                return new AadEnvironment(
                    @"Production",
                    @"login.windows.net",
                    @"graph.windows.net",
                    aadGraphApiVersions,
                    new AadGraphApiUrlFormatter());
            }
        }
        public static AadEnvironment MSGraphProduction
        {
            get
            {
                return new AadEnvironment(
                    @"Production",
                    @"login.windows.net",
                    @"graph.microsoft.com",
                    msGraphApiVersions,
                    new MSGraphApiUrlFormatter());
            }
        }

        public static AadEnvironment AadGraphPreProduction
        {
            get
            {
                return new AadEnvironment(
                    @"PPE",
                    @"login.windows-ppe.net",
                    @"graph.ppe.windows.net",
                    aadGraphApiVersions,
                    new AadGraphApiUrlFormatter());
            }
        }

        public static AadEnvironment MSGraphPreProduction
        {
            get
            {
                return new AadEnvironment(
                    @"PPE",
                    @"login.windows-ppe.net",
                    @"graph.microsoft-ppe.com",
                    msGraphApiVersions,
                    new MSGraphApiUrlFormatter());
            }
        }
    }
}
