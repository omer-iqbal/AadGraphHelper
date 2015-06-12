using System;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace AadGraphApiHelper
{
    internal class Token
    {
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
            AuthenticationResult authenticationResult = ac.AcquireToken(
                tenantCredential.Environment.GraphResourceUrl,
                tenantCredential.ClientId,
                tenantCredential.ReplyUrl,
                PromptBehavior.Always);
            return authenticationResult.CreateAuthorizationHeader();
        }
    }
}
