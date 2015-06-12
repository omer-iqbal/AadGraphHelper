namespace AadGraphApiHelper
{
    internal class TenantCredentialCollection : SortedCollection<string, TenantCredential>
    {
        public override string GetKeyForItem(TenantCredential item)
        {
            return item.DisplayName.ToUpperInvariant();
        }
    }
}
