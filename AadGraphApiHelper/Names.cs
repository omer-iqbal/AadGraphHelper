namespace AadGraphApiHelper
{
    internal class Names
    {
        // Entity types
        public const string Applications = @"applications";
        public const string Contacts = @"contacts";
        public const string Contracts = @"contracts";
        public const string Devices = @"devices";
        public const string DirectoryRoles = @"directoryRoles";
        public const string DirectoryRoleTemplates = @"directoryRoleTemplates";
        public const string ExtensionProperties = @"extensionProperties";
        public const string Groups = @"groups";
        public const string Metadata = @"$metadata";
        public const string ObjectType = @"objectType";
        public const string ServicePrincipals = @"servicePrincipals";
        public const string TenantDetails = @"tenantDetails";
        public const string Users = @"users";
        public const string SubscribedSkus = @"subscribedSkus";

        // Functions
        public const string GetAvailableExtensionProperties = @"getAvailableExtensionProperties";
        public const string GetMemberGroups = @"getMemberGroups";
        public const string CheckMemberGroups = @"CheckMemberGroups";

        // Navigation properties
        public const string AppRoleAssignedTo = @"appRoleAssignedTo";
        public const string AppRolesAssignedToLinks = @"$links/appRoleAssignedTo";
        public const string AppRoleAssignments = @"appRoleAssignments";
        public const string AppRoleAssignmentsLinks = @"$links/appRoleAssignments";
        public const string CreatedObjects = @"createdObjects";
        public const string CreatedObjectsLinks = @"$links/createdObjects";
        public const string DirectReports = @"directReports";
        public const string DirectReportsLinks = @"$links/directReports";
        public const string Manager = @"manager";
        public const string ManagerLinks = @"$links/manager";
        public const string MemberOf = @"memberOf";
        public const string MemberOfLinks = @"$links/memberOf";
        public const string Members = @"members";
        public const string MembersLinks = @"$links/members";
        public const string OAuth2PermissionGrants = @"oauth2PermissionGrants";
        public const string OAuth2PermissionGrantsLinks = @"$links/oauth2PermissionGrants";
        public const string OwnedDevices = @"ownedDevices";
        public const string OwnedDevicesLinks = @"$links/ownedDevices";
        public const string OwnedObjects = @"ownedObjects";
        public const string OwnedObjectsLinks = @"$links/ownedObjects";
        public const string Owners = @"owners";
        public const string OwnersLinks = @"$links/owners";
        public const string RegisteredDevices = @"registeredDevices";
        public const string RegisteredDevicesLinks = @"$links/registeredDevices";
        public const string RegisteredOwners = @"registeredOwners";
        public const string RegisteredOwnersLinks = @"$links/registeredOwners";
        public const string RegisteredUsers = @"registeredUsers";
        public const string RegisteredUsersLinks = @"$links/registeredUsers";

        // Built-in properties applicable to multiple objects
        public const string ObjectId = @"objectId";
        public const string Id = @"id";
        public const string DisplayName = @"displayName";

        // Build-in user properties
        public const string AccountEnabled = @"accountEnabled";
        public const string AssignedLicenses = @"assignedLicenses";
        public const string AssignedPlans = @"assignedPlans";
        public const string City = @"city";
        public const string Country = @"country";
        public const string DeletionTimeStamp = @"deletionTimeStamp";
        public const string Department = @"department";
        public const string DirSyncEnabled = @"dirSyncEnabled";
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

        // Built-in application/servicePrincipal properties
        public const string AppDisplayName = @"appDisplayName";
        public const string AppOwnerTenantId = @"appOwnerTenantId";
        public const string AppRoleAssignmentRequired = @"appRoleAssignmentRequired";
        public const string OAuth2Permissions = @"oauth2Permissions";
        public const string PreferredTokenSigningKeyThumbprint = @"preferredTokenSigningKeyThumbprint";
        public const string PublisherName = @"publisherName";
        public const string ServicePrincipalNames = @"servicePrincipalNames";
        public const string Tags = @"tags";
        public const string AppId = @"appId";
        public const string AppRoles = @"appRoles";
        public const string AvailableToOtherTenants = @"availableToOtherTenants";
        public const string ErrorUrl = @"errorUrl";
        public const string GroupMembershipClaims = @"groupMembershipClaims";
        public const string HomePage = @"homePage";
        public const string IdentifierUris = @"identifierUris";
        public const string LogoutUrl = @"logoutUrl";
        public const string OAuth2AllowImplicitFlow = @"oauth2AllowImplicitFlow";
        public const string OAuth2AllowUrlPathMatching = @"oauth2AllowUrlPathMatching";
        public const string OAuth2RequiredResponse = @"oauth2RequiredResponse";
        public const string PublicClient = @"publicClient";
        public const string ReplyUrls = @"replyUrls";
        public const string SamlMetadataUrl = @"samlMetadataUrl";

        // Built-in group/directoryRole propeties
        public const string Description = @"description";
        public const string MailEnabled = @"mailEnabled";
        public const string SecurityEnabled = @"securityEnabled";

        // Filter query operators
        public const string AndOperator = @"and";
        public const string OrOperator = @"or";

        public const string StartsWithOperator = @"startswith";
        public const string EqualToOperator = @"eq";
        public const string GreaterThanOrEqualToOperator = @"ge";
        public const string LessThanOrEqualToOperator = @"le";
        public const string AnyEqualsOperator = @"any (eq)";
    }
}
