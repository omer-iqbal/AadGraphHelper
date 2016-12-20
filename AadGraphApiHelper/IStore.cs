namespace AadGraphApiHelper
{
    internal interface IStore
    {
        void Store(AadEnvironment environment);

        AadEnvironmentSet GetAadEnvironments();

        void Store(TenantCredential tenantCredential);

        TenantCredentialSet GetTenantCredentials(AadEnvironment environment);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="environment"></param>
        /// <param name="tenantCredential"></param>
        /// <returns>true if delete successful</returns>
        bool RemoveTenantCredentials(TenantCredential tenantCredential);

        void Store(string apiVersion);

        ApiVersionSet GetApiVersions(); 

        void SavePreference(string key, object value);

        T GetPreference<T>(string key);
    }
}
