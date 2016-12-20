using System;
using Microsoft.Win32;

namespace AadGraphApiHelper
{
    internal class RegistryStore : IStore
    {
        private const string RegistryRoot = @"Software\Microsoft\AadGraphApiBuddy";

        private const string EnvironmentsRoot = RegistryRoot + @"\Environments";

        private const string ApiVersionRoot = RegistryRoot + @"\ApiVersions";

        private const string LoginEndpointKey = @"LoginEndpoint";

        private const string GraphApiEndpointKey = @"GraphApiEndpoint";

        private const string EncryptedKeyKey = @"EncryptedKey";

        private const string ApplicationTypeKey = @"ApplicationType";

        private const string ReplyUrlKey = @"ReplyUrl";

        public void Store(AadEnvironment environment)
        {
            string environmentPath = GetEnvironmentPath(environment);
            using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(environmentPath))
            {
                if (registryKey == null)
                {
                    return;
                }

                registryKey.SetValue(LoginEndpointKey, environment.LoginEndpoint);
                registryKey.SetValue(GraphApiEndpointKey, environment.GraphApiEndpoint);
            }
        }

        public void Delete(AadEnvironment environment)
        {
        }

        public AadEnvironmentSet GetAadEnvironments()
        {
            return new AadEnvironmentSet();

            //using (RegistryKey environmentsRootKey = Registry.CurrentUser.CreateSubKey(EnvironmentsRoot))
            //{
            //    if (environmentsRootKey == null)
            //    {
            //        return environments;
            //    }

            //    foreach (string environmentName in environmentsRootKey.GetSubKeyNames())
            //    {
            //        if (environmentName.Equals(AadEnvironment.MSGraphProduction.RegistryName, StringComparison.OrdinalIgnoreCase) ||
            //            environmentName.Equals(AadEnvironment.AadGraphProduction.RegistryName, StringComparison.OrdinalIgnoreCase) ||
            //            environmentName.Equals(AadEnvironment.AadGraphPreProduction.RegistryName, StringComparison.OrdinalIgnoreCase))
            //        {
            //            // These keys are created to store tenants/credentials, but we do not add them since they have
            //            // been added already. Their endpoints are not read from the registry.
            //            continue;
            //        }

            //        using (RegistryKey environmentKey = environmentsRootKey.OpenSubKey(environmentName))
            //        {
            //            if (environmentKey == null)
            //            {
            //                continue;
            //            }

            //            string loginEndpoint = environmentKey.GetValue(LoginEndpointKey) as string;
            //            string graphApiEndpoint = environmentKey.GetValue(GraphApiEndpointKey) as string;

            //            if (String.IsNullOrWhiteSpace(loginEndpoint) || String.IsNullOrWhiteSpace(graphApiEndpoint))
            //            {
            //                continue;
            //            }

            //            environments.Add(new AadEnvironment(environmentName, loginEndpoint.Trim(), graphApiEndpoint.Trim()));
            //        }
            //    }
            //}

            //return environments;
        }

        public void Store(TenantCredential tenantCredential)
        {
            string credentialPath = GetCredentialPath(tenantCredential);
            
            using (RegistryKey credentialKey = Registry.CurrentUser.CreateSubKey(credentialPath))
            {
                if (credentialKey == null)
                {
                    return;
                }

                credentialKey.SetValue(ApplicationTypeKey, tenantCredential.ApplicationType.ToString());

                if (tenantCredential.ApplicationType == ApplicationType.Native)
                {
                    credentialKey.SetValue(ReplyUrlKey, tenantCredential.ReplyUrl);
                }
                else
                {
                    credentialKey.SetValue(EncryptedKeyKey, tenantCredential.EncryptedKey);
                }
            }
        }

        public bool Delete(TenantCredential tbdTenantCredential)
        {
            string environmentPath = GetEnvironmentPath(tbdTenantCredential.Environment);
            using (RegistryKey environmentKey = Registry.CurrentUser.OpenSubKey(environmentPath))
            {
                if (environmentKey == null)
                {
                    return false;
                }

                foreach (string tenant in environmentKey.GetSubKeyNames())
                {
                    using (RegistryKey tenantKey = environmentKey.OpenSubKey(tenant))
                    {
                        bool found = false;
                        if (tenantKey == null)
                        {
                            continue;
                        }

                        foreach (string clientId in tenantKey.GetSubKeyNames())
                        {
                            using (RegistryKey clientIdKey = tenantKey.OpenSubKey(clientId))
                            {
                                if (String.IsNullOrWhiteSpace(clientId))
                                {
                                    continue;
                                }

                                if (clientIdKey == null)
                                {
                                    continue;
                                }

                                string applicationTypeString = clientIdKey.GetValue(ApplicationTypeKey) as string;
                                ApplicationType applicationType;
                                if (!Enum.TryParse(applicationTypeString, true, out applicationType))
                                {
                                    continue;
                                }

                                TenantCredential credential;
                                try
                                {
                                    credential = new TenantCredential(tbdTenantCredential.Environment, tenant, clientId, applicationType);
                                }
                                catch (Exception)
                                {
                                    // Bad key, can't decrypt :-(
                                    continue;
                                }

                                switch (applicationType)
                                {
                                    case ApplicationType.Native:
                                        string replyUrl = clientIdKey.GetValue(ReplyUrlKey) as string;
                                        if (string.IsNullOrWhiteSpace(replyUrl))
                                        {
                                            continue;
                                        }

                                        credential.ReplyUrl = new Uri(replyUrl);
                                        break;

                                    case ApplicationType.Web:
                                        byte[] encryptedKey = clientIdKey.GetValue(EncryptedKeyKey) as byte[];
                                        if (encryptedKey == null || encryptedKey.Length < 16)
                                        {
                                            continue;
                                        }

                                        credential.EncryptedKey = encryptedKey;
                                        break;
                                        
                                    default:
                                        // unknown application type :-(
                                        continue;
                                }


                                if (tbdTenantCredential.Equals(credential))
                                {
                                    found = true;
                                }
                            }

                            if (found)
                            {
                                break;
                            }
                        }

                        if (found)
                        {
                            tenantKey.DeleteSubKey(tbdTenantCredential.ClientId);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public TenantCredentialSet GetTenantCredentials(AadEnvironment environment)
        {
            TenantCredentialSet tenantCredentials = new TenantCredentialSet();
            string environmentPath = GetEnvironmentPath(environment);
            using (RegistryKey environmentKey = Registry.CurrentUser.OpenSubKey(environmentPath))
            {
                if (environmentKey == null)
                {
                    return tenantCredentials;
                }

                foreach (string tenant in environmentKey.GetSubKeyNames())
                {
                    using (RegistryKey tenantKey = environmentKey.OpenSubKey(tenant))
                    {
                        if (tenantKey == null)
                        {
                            continue;
                        }

                        foreach (string clientId in tenantKey.GetSubKeyNames())
                        {
                            using (RegistryKey clientIdKey = tenantKey.OpenSubKey(clientId))
                            {
                                if (String.IsNullOrWhiteSpace(clientId))
                                {
                                    continue;
                                }

                                if (clientIdKey == null)
                                {
                                    continue;
                                }

                                string applicationTypeString = clientIdKey.GetValue(ApplicationTypeKey) as string;
                                ApplicationType applicationType;
                                if (!Enum.TryParse(applicationTypeString, true, out applicationType))
                                {
                                    continue;
                                }

                                TenantCredential credential;
                                try
                                {
                                    credential = new TenantCredential(environment, tenant, clientId, applicationType);
                                }
                                catch (Exception)
                                {
                                    // Bad key, can't decrypt :-(
                                    continue;
                                }

                                switch (applicationType)
                                {
                                    case ApplicationType.Native:
                                        string replyUrl = clientIdKey.GetValue(ReplyUrlKey) as string;
                                        if (string.IsNullOrWhiteSpace(replyUrl))
                                        {
                                            continue;
                                        }

                                        credential.ReplyUrl = new Uri(replyUrl);
                                        break;

                                    case ApplicationType.Web:
                                        byte[] encryptedKey = clientIdKey.GetValue(EncryptedKeyKey) as byte[];
                                        if (encryptedKey == null || encryptedKey.Length < 16)
                                        {
                                            continue;
                                        }

                                        credential.EncryptedKey = encryptedKey;
                                        break;
                                        
                                    default:
                                        // unknown application type :-(
                                        continue;
                                }

                                tenantCredentials.Add(credential);
                            }
                        }
                    }
                }
            }

            return tenantCredentials;
        }

        public void Store(string apiVersion)
        {
            using (RegistryKey apiVersionKey = Registry.CurrentUser.CreateSubKey(ApiVersionRoot))
            {
                if (apiVersionKey == null)
                {
                    return;
                }

                apiVersionKey.SetValue(apiVersion, String.Empty);
            }
        }

        public ApiVersionSet GetApiVersions()
        {
            ApiVersionSet apiVersionCollection = new ApiVersionSet();
            using (RegistryKey apiVersionKey = Registry.CurrentUser.OpenSubKey(ApiVersionRoot))
            {
                if (apiVersionKey == null)
                {
                    return apiVersionCollection;
                }

                foreach (string apiVersion in apiVersionKey.GetValueNames())
                {
                    if (!apiVersionCollection.Contains(apiVersion))
                    {
                        apiVersionCollection.Add(apiVersion);
                    }
                }
            }

            return apiVersionCollection;
        }

        public void SavePreference(string key, object value)
        {
            using (RegistryKey preferenceKey = Registry.CurrentUser.CreateSubKey(RegistryRoot))
            {
                if (preferenceKey == null)
                {
                    return;
                }

                preferenceKey.SetValue(key, value);
            }
        }

        public T GetPreference<T>(string key)
        {
            using (RegistryKey preferenceKey = Registry.CurrentUser.OpenSubKey(RegistryRoot))
            {
                if (preferenceKey == null)
                {
                    return default(T);
                }

                object value = preferenceKey.GetValue(key);
                if (value == null)
                {
                    return default(T);
                }

                if (value is T)
                {
                    return (T)value;
                }

                return default(T);
            }
        }

        private static string GetEnvironmentPath(AadEnvironment environment)
        {
            return EnvironmentsRoot + '\\' + environment.RegistryName;
        }

        private static string GetTenantPath(AadEnvironment environment, string tenant)
        {
            string environmentPath = GetEnvironmentPath(environment);
            return environmentPath + '\\' + tenant;
        }

        private static string GetCredentialPath(TenantCredential tenantCredential)
        {
            string tenantPath = GetTenantPath(tenantCredential.Environment, tenantCredential.Tenant);
            return tenantPath + '\\' + tenantCredential.ClientId;
        }
    }
}
