using System;
using System.Windows.Forms;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AadGraphApiHelper
{
    internal class Token
    {
        private static TenantCredential lastUserTenantCredential = null;

        internal static string GetApplicationToken(TenantCredential tenantCredential)
        {
            string loginUrl = tenantCredential.Environment.GetLoginUrl(tenantCredential.Tenant);
            AuthenticationContext ac = new AuthenticationContext(loginUrl, false);
            ClientCredential clientCredential = new ClientCredential(tenantCredential.ClientId, tenantCredential.GetDecryptedKey());
            AuthenticationResult authenticationResult = ac.AcquireToken(tenantCredential.Environment.GraphResourceUrl, clientCredential);
            return authenticationResult.CreateAuthorizationHeader();
        }

        internal static string GetUserToken(TenantCredential tenantCredential)
        {
            string loginUrl = tenantCredential.Environment.GetLoginUrl(tenantCredential.Tenant);
            AuthenticationContext ac = new AuthenticationContext(loginUrl, false);

            var promptBehaviour = PromptBehavior.Auto;

            if (lastUserTenantCredential != null && !lastUserTenantCredential.Tenant.Equals(tenantCredential.Tenant))
            {
                promptBehaviour = PromptBehavior.Always;
            }

            lastUserTenantCredential = tenantCredential;

            AuthenticationResult authenticationResult = ac.AcquireToken(
            tenantCredential.Environment.GraphResourceUrl,
            tenantCredential.ClientId,
            tenantCredential.ReplyUrl,
            promptBehaviour);

            return authenticationResult.CreateAuthorizationHeader();
            
        }
    }
}
