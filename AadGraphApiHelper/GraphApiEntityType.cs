using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private static readonly GraphApiEntityType users;

        static GraphApiEntityType()
        {
            users = new GraphApiEntityType(Names.Users)
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
                    new GraphApiProperty(Names.LastDirSyncTime, typeof(DateTime), true),
                    new GraphApiProperty(Names.Mail, typeof(string), true),
                    new GraphApiProperty(Names.MailNickName, typeof(string), true),
                    new GraphApiProperty(Names.Mobile, typeof(string), false),
                    new GraphApiProperty(Names.ObjectId, typeof(Guid), false), // This is technically filterable, but only with eq operator
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
            };
        }

        private GraphApiEntityType(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(StringResources.NameCannotBeNullOrWhiteSpace, "name");
            }

            this.Name = name;
        }

        public string Name { get; private set; }

        public IReadOnlyCollection<GraphApiProperty> Properties { get; private set; }

        public static GraphApiEntityType Users
        {
            get { return users; }
        }
    }
}
