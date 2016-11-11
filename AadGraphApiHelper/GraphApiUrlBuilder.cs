using System;
using System.Collections.Generic;

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

        private IList<GraphApiUrlFilterComponent> filterComponents = new List<GraphApiUrlFilterComponent>();

        public IList<GraphApiUrlFilterComponent> FilterComponents
        {
            get { return this.filterComponents; }
        }

        public string CreateUrl()
        {
            IGraphApiUrlFormatter formatter = this.Environment?.UrlFormatter;

            return formatter?.FormatUrl(this) ?? String.Empty;
        }
    }
}
