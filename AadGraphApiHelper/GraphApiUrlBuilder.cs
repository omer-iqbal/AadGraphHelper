using System;

namespace AadGraphApiHelper
{
    internal class GraphApiUrlBuilder
    {
        public string ResourceFirst { get; set; }

        public string ResourceId { get; set; }

        public string ResourceSecond { get; set; }

        public string ApiVersion { get; set; }

        public AadEnvironment Environment { get; set; }

        public TenantCredential TenantCredential { get; set; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return this.Url;
        }

        public string Url
        {
            get
            {
                if (this.Environment == null ||
                    this.TenantCredential == null ||
                    String.IsNullOrWhiteSpace(this.ResourceFirst) ||
                    String.IsNullOrWhiteSpace(this.ApiVersion))
                {
                    return null;
                }

                UriBuilder uriBuilder = new UriBuilder(this.Environment.GraphResourceUrl);
                uriBuilder.Query = "api-version=" + this.ApiVersion;
                uriBuilder.Path = this.TenantCredential.Tenant + '/' + this.ResourceFirst;
                if (!String.IsNullOrWhiteSpace(this.ResourceId))
                {
                    uriBuilder.Path += '/' + this.ResourceId;
                }

                if (!String.IsNullOrWhiteSpace(this.ResourceSecond))
                {
                    uriBuilder.Path += '/' + this.ResourceSecond;
                }

                uriBuilder.Port = -1;
                return uriBuilder.ToString();
            }
        }
    }
}
