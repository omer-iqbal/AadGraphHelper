using System;
using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace AadGraphApiHelper
{
    internal class TenantCredential : IEquatable<TenantCredential>, IComparable<TenantCredential>
    {
        private Uri replyUrl;

        public TenantCredential(AadEnvironment environment, string tenant, string clientId, ApplicationType applicationType, string alias)
        {
            if (environment == null)
            {
                throw new ArgumentException(StringResources.EnvironmentCannotBeNull);
            }

            if (String.IsNullOrEmpty(tenant))
            {
                throw new ArgumentException(StringResources.TenantCannotBeNullOrWhiteSpace);
            }

            if (String.IsNullOrWhiteSpace(clientId))
            {
                throw new ArgumentException(StringResources.ClientIdCannotBeNullOrWhiteSpace);
            }

            Guid ignored;
            if (!Guid.TryParse(clientId, out ignored))
            {
                throw new ArgumentException(StringResources.ClientIdMustBeAGuid);
            }

            this.Environment = environment;
            this.Tenant = tenant;
            this.ClientId = clientId;
            this.ApplicationType = applicationType;
            this.Alias = alias;
        }

        public AadEnvironment Environment { get; private set; }

        public string Tenant { get; private set; }

        public ApplicationType ApplicationType { get; private set; }

        public byte[] EncryptedKey { get; set; }

        public string ClientId { get; set; }

        public Uri ReplyUrl 
        {
            get
            {
                return this.replyUrl;
            }

            set
            {
                if (value == null)
                {
                    this.replyUrl = null;
                    return;
                }

                if (this.ApplicationType != ApplicationType.Native)
                {
                    throw new ArgumentException(StringResources.ReplyUrlCannotBeSet);
                }

                this.replyUrl = value;
            }
        }

        public string Alias { get; set; }

        public string GetDecryptedKey()
        {
            byte[] plainBytes = ProtectedData.Unprotect(this.EncryptedKey, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(plainBytes);
        }

        public void EncryptAndSetKey(string key)
        {
            if (key == null)
            {
                this.EncryptedKey = null;
                return;
            }

            if (this.ApplicationType != ApplicationType.Web)
            {
                throw new ArgumentException(StringResources.KeyCannotBeSet);
            }

            byte[] plainBytes = Encoding.UTF8.GetBytes(key);
            this.EncryptedKey = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="obj">The object to compare with the current object. </param>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            return this.Equals(obj as TenantCredential);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(TenantCredential other)
        {
            if (other == null)
            {
                return false;
            }

            bool areEqual = this.Tenant.Equals(other.Tenant, StringComparison.OrdinalIgnoreCase) &&
                            this.ClientId.Equals(other.ClientId, StringComparison.OrdinalIgnoreCase) &&
                            this.ApplicationType == other.ApplicationType &&
                            String.Equals(this.Alias, other.Alias, StringComparison.OrdinalIgnoreCase);

            if (!areEqual)
            {
                return false;
            }

            if (this.ApplicationType == ApplicationType.Native)
            {
                return this.ReplyUrl.Equals(other.ReplyUrl);
            }

            if ((this.EncryptedKey == null && other.EncryptedKey != null) ||
                (this.EncryptedKey != null && other.EncryptedKey == null))
            {
                return false;
            }

            if (this.EncryptedKey == null || other.EncryptedKey == null)
            {
                return true;
            }

            return this.EncryptedKey.SequenceEqual(other.EncryptedKey);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int hashCode = (this.Tenant + "::" + this.ClientId).GetHashCode() ^ this.ApplicationType.GetHashCode();

            if (this.ApplicationType == ApplicationType.Native)
            {
                return hashCode ^ this.ReplyUrl.GetHashCode();
            }

            return hashCode ^ this.EncryptedKey.GetHashCode();
        }

        /// <summary>
        /// Compares the current object with another object of the same type.
        /// </summary>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has the following meanings: 
        /// Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.
        /// Zero This object is equal to <paramref name="other"/>. 
        /// Greater than zero This object is greater than <paramref name="other"/>. 
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public int CompareTo(TenantCredential other)
        {
            if (other == null)
            {
                return 1;
            }

            // Compare value is used primarily for sorting purposes, and by using ToString(), we ensure that if representation is 
            // changed in the future, CompareTo will be reflective of it.
            int compareValue = this.ToString().ToUpperInvariant().CompareTo(other.ToString().ToUpperInvariant());
            return compareValue;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            string alias = string.IsNullOrEmpty(this.Alias) ? "" : this.Alias + ": ";
            return alias + this.Tenant + @" (" + this.ClientId + @")";
        }
    }
}
