using System;
using System.Globalization;

namespace AadGraphApiHelper
{
    internal class AadEnvironment : IEquatable<AadEnvironment>, IComparable<AadEnvironment>
    {
        private const string UrlFormat = @"https://{0}/{1}";

        public AadEnvironment(string displayName, string loginEndpoint, string graphApiEndpoint)
        {
            this.DisplayName = displayName;
            this.LoginEndpoint = loginEndpoint;
            this.GraphApiEndpoint = graphApiEndpoint;
        }

        public static AadEnvironment Production 
        {
            get
            {
                return new AadEnvironment(@"Production", @"login.windows.net", @"graph.windows.net");
            }
        }

        public static AadEnvironment PreProduction
        {
            get
            {
                return new AadEnvironment(@"PPE", @"login.windows-ppe.net", @"graph.ppe.windows.net");
            }
        }

        public string DisplayName { get; private set; }

        public string LoginEndpoint { get; private set; }

        public string GraphApiEndpoint { get; private set; }

        public string GraphResourceUrl
        {
            get
            {
                return String.Format(CultureInfo.InvariantCulture, @"https://{0}", this.GraphApiEndpoint);
            }
        }

        public string GetLoginUrl(string tenant)
        {
            return String.Format(UrlFormat, this.LoginEndpoint, tenant);
        }

        public string GetTenantGraphUrl(string tenant)
        {
            return String.Format(UrlFormat, this.GraphApiEndpoint, tenant);
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

            return this.Equals(obj as AadEnvironment);
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        /// <param name="other">An object to compare with this object.</param>
        public bool Equals(AadEnvironment other)
        {
            if (other == null)
            {
                return false;
            }

            return this.DisplayName.Equals(other.DisplayName, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Serves as a hash function for a particular type. 
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return this.DisplayName.ToUpperInvariant().GetHashCode();
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
        public int CompareTo(AadEnvironment other)
        {
            if (other == null)
            {
                return -1;
            }

            return this.DisplayName.ToUpperInvariant().CompareTo(other.DisplayName.ToUpperInvariant());
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return this.DisplayName;
        }
    }
}
