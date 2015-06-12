using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AadGraphApiHelper
{
    internal class Names
    {
        public const string Users = @"users";

        public const string Applications = @"applications";

        public const string ServicePrincipals = @"servicePrincipals";

        public const string TenantDetails = @"tenantDetails";

        public const string Groups = @"groups";

        public const string Metadata = @"$metadata";

        public const string ExtensionProperties = @"extensionProperties";

        // Functions
        public const string GetAvailableExtensionProperties = @"getAvailableExtensionProperties";


        //public const string ;

        // User operations
        public const string MemberOf = @"memberOf";

        public const string MemberOfLinks = @"$links/memberOf";

        public const string Manager = @"manager";

        public const string ManagerLinks = @"$links/manager";

        public const string DirectReports = @"directReports";

        public const string DirectReportsLinks = @"$links/directReports";

        public const string Members = @"$members";

        public const string MembersLinks = @"$links/members";

        //public const string ;

        // Operations on multiple entities

        // Acceptable values are users, groups, contacts, and servicePrincipals.
        public const string CheckMemberGroups = @"CheckMemberGroups";

        // Acceptable values are users, groups, contacts, and servicePrincipals.
        public const string GetMemberGroups = @"getMemberGroups";

        // Built-in Properties
        public const string ObjectId = @"objectId";
    }
}
