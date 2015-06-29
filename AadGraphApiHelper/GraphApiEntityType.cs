using System;
using System.Collections.Generic;

namespace AadGraphApiHelper
{
    // Ideally we would get this from the service metadata. However, certain 
    // information, such as which properties are filterable, is not available 
    // in the service metadata, and needs to be hardcoded. Then, instead of 
    // splitting information (i.e. some hardcoded, and some
    // retrieved from metadata), all the information is hardcoded here.
    // 
    // TODO: The only place where getting the service metadata will be useful 
    // would be to determine which properties are available in which api versions.
    internal class GraphApiEntityType
    {
        // TODO: Merge navigation properties into the entity, after entity types are added for all objects
        private static readonly IDictionary<string, ISet<string>> navigationProperties = new Dictionary<string, ISet<string>>(StringComparer.OrdinalIgnoreCase)
        {
            {
                Names.Applications, new HashSet<string>
                {
                    Names.Owners,
                    Names.OwnersLinks,
                    Names.ExtensionProperties
                }
            },
            {
                Names.Contacts, new HashSet<string>
                {
                    Names.Manager, 
                    Names.ManagerLinks, 
                    Names.DirectReports, 
                    Names.DirectReportsLinks, 
                    Names.MemberOf,
                    Names.MemberOfLinks
                }
            },
            {
                Names.Contracts, new HashSet<string>()
            },
            {
                Names.Devices, new HashSet<string>
                {
                    Names.RegisteredOwners,
                    Names.RegisteredOwnersLinks,
                    Names.RegisteredUsers,
                    Names.RegisteredUsersLinks
                }
            },
            {
                Names.DirectoryRoles, new HashSet<string>
                {
                    Names.Members, 
                    Names.MembersLinks
                }
            },
            {
                Names.DirectoryRoleTemplates, new HashSet<string>()
            },
            {
                Names.Groups, new HashSet<string>
                {
                    Names.Members, 
                    Names.MembersLinks,
                    Names.MemberOf,
                    Names.MemberOfLinks,
                    Names.Owners,
                    Names.OwnersLinks,
                    Names.AppRoleAssignments,
                    Names.AppRoleAssignmentsLinks
                }
            },
            {
                Names.ServicePrincipals, new HashSet<string>
                {
                    Names.AppRoleAssignedTo,
                    Names.AppRolesAssignedToLinks,
                    Names.AppRoleAssignments,
                    Names.AppRoleAssignmentsLinks,
                    Names.CreatedObjects,
                    Names.CreatedObjectsLinks,
                    Names.MemberOf,
                    Names.MemberOfLinks,
                    Names.OAuth2PermissionGrants,
                    Names.OAuth2PermissionGrantsLinks,
                    Names.OwnedObjects,
                    Names.OwnedObjectsLinks,
                    Names.Owners,
                    Names.OwnersLinks
                }
            },
            {
                Names.SubscribedSkus, new HashSet<string>()
            },
            {
                Names.TenantDetails, new HashSet<string>()
            },
            {
                Names.Users, new HashSet<string>
                {
                    Names.Manager, 
                    Names.ManagerLinks, 
                    Names.DirectReports, 
                    Names.DirectReportsLinks, 
                    Names.MemberOf, 
                    Names.MemberOfLinks, 
                    Names.OwnedDevices, 
                    Names.OwnedDevicesLinks, 
                    Names.RegisteredDevices,
                    Names.RegisteredDevicesLinks,
                    Names.CreatedObjects,
                    Names.CreatedObjectsLinks,
                    Names.OwnedObjects,
                    Names.OwnedObjectsLinks,
                    Names.AppRoleAssignments,
                    Names.AppRoleAssignmentsLinks,
                    Names.OAuth2PermissionGrants,
                    Names.OAuth2PermissionGrantsLinks,
                    Names.CheckMemberGroups, 
                    Names.GetMemberGroups
                } 
            }
        };

        private static readonly IList<GraphApiEntityType> entities = new List<GraphApiEntityType>
        {
            new GraphApiEntityType(Names.Applications)
            {
                Properties = new List<GraphApiProperty>
                {
                    new GraphApiProperty(Names.AppId, typeof(string), true),
                    new GraphApiProperty(Names.AvailableToOtherTenants, typeof(bool), true),
                    new GraphApiProperty(Names.DisplayName, typeof(string), true),
                    new GraphApiProperty(Names.ErrorUrl, typeof(string), false),
                    new GraphApiProperty(Names.GroupMembershipClaims, typeof(string), false),
                    new GraphApiProperty(Names.HomePage, typeof(string), false),
                    new GraphApiProperty(Names.IdentifierUris, typeof(ICollection<string>), true),
                    new GraphApiProperty(Names.LogoutUrl, typeof(string), false),
                    new GraphApiProperty(Names.OAuth2AllowImplicitFlow, typeof(bool), false),
                    new GraphApiProperty(Names.OAuth2AllowUrlPathMatching, typeof(bool), false),
                    new GraphApiProperty(Names.OAuth2RequiredResponse, typeof(Guid), false),
                    new GraphApiProperty(Names.ObjectId, typeof(Guid), true),
                    new GraphApiProperty(Names.ObjectType, typeof(string), false),
                    new GraphApiProperty(Names.PublicClient, typeof(bool), false),
                    new GraphApiProperty(Names.ReplyUrls, typeof(ICollection<string>), false),
                    new GraphApiProperty(Names.SamlMetadataUrl, typeof(string), false)
                }
            },
            new GraphApiEntityType(Names.Groups)
            {
                Properties = new List<GraphApiProperty>
                {
                    new GraphApiProperty(Names.Description, typeof(string), false),
                    new GraphApiProperty(Names.DirSyncEnabled, typeof(bool), true),
                    new GraphApiProperty(Names.DisplayName, typeof(string), true),
                    new GraphApiProperty(Names.LastDirSyncTime, typeof(DateTime), false), // TODO: make it enabled and add search for date/times
                    new GraphApiProperty(Names.Mail, typeof(string), true),
                    new GraphApiProperty(Names.MailEnabled, typeof(bool), false),
                    new GraphApiProperty(Names.MailNickName, typeof(string), true),
                    new GraphApiProperty(Names.ObjectId, typeof(Guid), true),
                    new GraphApiProperty(Names.ObjectType, typeof(string), false),
                    new GraphApiProperty(Names.OnPremisesSecurityIdentifier, typeof(string), false),
                    new GraphApiProperty(Names.ProxyAddresses, typeof(ICollection<string>), true),
                    new GraphApiProperty(Names.SecurityEnabled, typeof(bool), false)
                }
            },
            new GraphApiEntityType(Names.ServicePrincipals)
            {
                Properties = new List<GraphApiProperty>
                {
                    new GraphApiProperty(Names.AccountEnabled, typeof(bool), true),
                    new GraphApiProperty(Names.AppDisplayName, typeof(string), false),
                    new GraphApiProperty(Names.AppId, typeof(string), true),
                    new GraphApiProperty(Names.AppOwnerTenantId, typeof(Guid), false),
                    new GraphApiProperty(Names.AppRoleAssignmentRequired, typeof(bool), false),
                    new GraphApiProperty(Names.DisplayName, typeof(string), true),
                    new GraphApiProperty(Names.ErrorUrl, typeof(string), false),
                    new GraphApiProperty(Names.HomePage, typeof(string), false),
                    new GraphApiProperty(Names.LogoutUrl, typeof(string), false),
                    new GraphApiProperty(Names.OAuth2Permissions, typeof(bool), false),
                    new GraphApiProperty(Names.ObjectId, typeof(Guid), true),
                    new GraphApiProperty(Names.ObjectType, typeof(string), false),
                    new GraphApiProperty(Names.PreferredTokenSigningKeyThumbprint, typeof(string), false),
                    new GraphApiProperty(Names.PublisherName, typeof(string), true),
                    new GraphApiProperty(Names.ReplyUrls, typeof(ICollection<string>), false),
                    new GraphApiProperty(Names.SamlMetadataUrl, typeof(string), false),
                    new GraphApiProperty(Names.ServicePrincipalNames, typeof(ICollection<string>), true),
                    new GraphApiProperty(Names.Tags, typeof(ICollection<string>), true)
                }
            },
            new GraphApiEntityType(Names.Users)
            {
                Properties = new List<GraphApiProperty>
                {
                    new GraphApiProperty(Names.AccountEnabled, typeof(bool), true),
                    new GraphApiProperty(Names.City, typeof(string), true),
                    new GraphApiProperty(Names.Country, typeof(string), true),
                    new GraphApiProperty(Names.DeletionTimeStamp, typeof(DateTime), false),
                    new GraphApiProperty(Names.Department, typeof(string), true),
                    new GraphApiProperty(Names.DirSyncEnabled, typeof(bool), true),
                    new GraphApiProperty(Names.DisplayName, typeof(string), true),
                    new GraphApiProperty(Names.FacsimileTelephoneNumber, typeof(string), false),
                    new GraphApiProperty(Names.GivenName, typeof(string), true),
                    new GraphApiProperty(Names.ImmutableId, typeof(string), true),
                    new GraphApiProperty(Names.JobTitle, typeof(string), true),
                    new GraphApiProperty(Names.LastDirSyncTime, typeof(DateTime), false), // TODO: Make it enabled and add search for date/times
                    new GraphApiProperty(Names.Mail, typeof(string), true),
                    new GraphApiProperty(Names.MailNickName, typeof(string), true),
                    new GraphApiProperty(Names.Mobile, typeof(string), false),
                    new GraphApiProperty(Names.ObjectId, typeof(Guid), true),
                    new GraphApiProperty(Names.ObjectType, typeof(string), false),
                    new GraphApiProperty(Names.OnPremisesSecurityIdentifier, typeof(string), false),
                    new GraphApiProperty(Names.OtherMails, typeof(ICollection<string>), true),
                    new GraphApiProperty(Names.PasswordPolicies, typeof(string), false),
                    new GraphApiProperty(Names.PhysicalDeliveryOfficeName, typeof(string), false),
                    new GraphApiProperty(Names.PostalCode, typeof(string), false),
                    new GraphApiProperty(Names.PreferredLanguage, typeof(string), false),
                    new GraphApiProperty(Names.ProxyAddresses, typeof(ICollection<string>), true),
                    new GraphApiProperty(Names.SipProxyAddress, typeof(string), false),
                    new GraphApiProperty(Names.State, typeof(string), true),
                    new GraphApiProperty(Names.StreetAddress, typeof(string), false),
                    new GraphApiProperty(Names.Surname, typeof(string), true),
                    new GraphApiProperty(Names.TelephoneNumber, typeof(string), false),
                    new GraphApiProperty(Names.UsageLocation, typeof(string), true),
                    new GraphApiProperty(Names.UserPrincipalName, typeof(string), true),
                    new GraphApiProperty(Names.UserType, typeof(string), true)
                }
            }
        };

        private GraphApiEntityType(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(StringResources.NameCannotBeNullOrWhiteSpace, "name");
            }

            this.Name = name;
        }

        public string Name { get; private set; }

        public static ICollection<GraphApiEntityType> Entities
        {
            get { return entities; }
        }

        public IReadOnlyCollection<GraphApiProperty> Properties { get; private set; }

        // TODO: Merge navigation properties into the entity, after entity types are added for all objects
        internal static IDictionary<string, ISet<string>> NavigationProperties
        {
            get { return navigationProperties; }
        }
    }
}
