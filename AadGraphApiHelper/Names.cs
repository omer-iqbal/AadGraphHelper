namespace AadGraphApiHelper
{
    internal class Names
    {
        internal const string Users = @"users";

        public const string Applications = @"applications";

        public const string ServicePrincipals = @"servicePrincipals";

        public const string TenantDetails = @"tenantDetails";

        public const string Groups = @"groups";

        public const string Metadata = @"$metadata";

        public const string ExtensionProperties = @"extensionProperties";

        public const string ObjectType = @"objectType";
        
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

        // Built-in properties applicable to all objects
        public const string ObjectId = @"objectId";

        // Build-in user properties
        public const string AccountEnabled = @"accountEnabled";
        public const string AssignedLicenses = @"assignedLicenses";
        public const string AssignedPlans = @"assignedPlans";
        public const string City = @"city";
        public const string Country = @"country";
        public const string DeletionTimeStamp = @"deletionTimeStamp";
        public const string Department = @"department";
        public const string DirSyncEnabled = @"dirSyncEnabled";
        public const string DisplayName = @"displayName";
        public const string FacsimileTelephoneNumber = @"facsimileTelephoneNumber";
        public const string GivenName = @"givenName";
        public const string ImmutableId = @"immutableId";
        public const string JobTitle = @"jobTitle";
        public const string LastDirSyncTime = @"lastDirSyncTime";
        public const string Mail = @"mail";
        public const string MailNickName = @"mailNickName";
        public const string Mobile = @"mobile";
        public const string OnPremisesSecurityIdentifier = @"onPremisesSecurityIdentifier";
        public const string OtherMails = @"otherMails";
        public const string PasswordPolicies = @"passwordPolicies";
        public const string PasswordProfile = @"passwordProfile";
        public const string PhysicalDeliveryOfficeName = @"physicalDeliveryOfficeName";
        public const string PostalCode = @"postalCode";
        public const string PreferredLanguage = @"preferredLanguage";
        public const string ProvisionedPlans = @"provisionedPlans";
        public const string ProxyAddresses = @"proxyAddresses";
        public const string SipProxyAddress = @"sipProxyAddress";
        public const string State = @"state";
        public const string StreetAddress = @"streetAddress";
        public const string Surname = @"surname";
        public const string TelephoneNumber = @"telephoneNumber";
        public const string ThumbnailPhoto = @"thumbnailPhoto";
        public const string UsageLocation = @"usageLocation";
        public const string UserPrincipalName = @"userPrincipalName";
        public const string UserType = @"userType";

        public const string AndOperator = @"and";
        public const string OrOperator = @"or";

        public const string StartsWithOperator = @"startswith";
        public const string EqualToOperator = @"eq";
        public const string NotEqualToOperator = @"neq";
        public const string GreaterThanOrEqualToOperator = @"ge";
        public const string LessThanOrEqualToOperator = @"le";
        public const string AnyEqualsOperator = @"any (eq)";
    }
}
