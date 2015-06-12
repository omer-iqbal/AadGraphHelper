using System;
using System.Security.Cryptography;
using System.Text;

namespace AadGraphApiHelper
{
    internal class TenantCredential : IEquatable<TenantCredential>, IComparable<TenantCredential>
    {
        private string clientId;

        public TenantCredential(AadEnvironment environment, string tenant, bool useUserAuthorization)
        {
            this.Environment = environment;
            this.Tenant = tenant;
            this.UseUserAuthorization = useUserAuthorization;
        }

        public AadEnvironment Environment { get; private set; }

        public string Tenant { get; private set; }

        public bool UseUserAuthorization { get; private set; }

        public string ClientId
        {
            get
            {
                return this.clientId;
            }

            set
            {
                if (this.UseUserAuthorization)
                {
                    throw new ArgumentException("ClientId cannot be provided when UseUserAuthorization is set to true.");
                }

                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("ClientId cannot be null or whitespace.");
                }

                this.clientId = value.Trim().ToLowerInvariant();
            }
        }

        public string GetDecryptedKey()
        {
            byte[] plainBytes = ProtectedData.Unprotect(this.EncryptedKey, null, DataProtectionScope.CurrentUser);
            return Encoding.UTF8.GetString(plainBytes);
        }

        public void EncryptAndSetKey(string key)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(key);
            this.EncryptedKey = ProtectedData.Protect(plainBytes, null, DataProtectionScope.CurrentUser);
        }

        public byte[] EncryptedKey { get; set; }

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
                            this.UseUserAuthorization == other.UseUserAuthorization;

            if (this.UseUserAuthorization == false && this.ClientId != null)
            {
                areEqual = areEqual && this.ClientId.Equals(other.ClientId, StringComparison.OrdinalIgnoreCase);
            }

            return areEqual;
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            string hashCodeString = this.Tenant + ':' + this.UseUserAuthorization;

            if (this.UseUserAuthorization == false && this.ClientId != null)
            {
                hashCodeString += ':' + this.ClientId;
            }

            return hashCodeString.GetHashCode();
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

            int compareValue = this.Tenant.ToUpperInvariant().CompareTo(other.Tenant.ToUpperInvariant());

            if (compareValue == 0)
            {
                compareValue = this.UseUserAuthorization.CompareTo(other.UseUserAuthorization);
            }

            if (compareValue == 0 && this.UseUserAuthorization == false)
            {
                if (this.ClientId == null && other.ClientId != null)
                {
                    return -1;
                }

                // ClientId is already normalized using ToLowerInvariant() in the setter.
                compareValue = this.ClientId.CompareTo(other.ClientId);
            }

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
            return this.Tenant + @" (" + this.ClientId + @")";
        }
    }
}
