using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return this.CreateUrl();
        }

        public string CreateUrl()
        {
            if (this.Environment == null ||
                this.TenantCredential == null ||
                String.IsNullOrWhiteSpace(this.ResourceFirst) ||
                String.IsNullOrWhiteSpace(this.ApiVersion))
            {
                return null;
            }

            UriBuilder uriBuilder = new UriBuilder(this.Environment.GraphResourceUrl);
            uriBuilder.Path = this.TenantCredential.Tenant + '/' + this.ResourceFirst;
            if (!String.IsNullOrWhiteSpace(this.ResourceId))
            {
                uriBuilder.Path += '/' + this.ResourceId;
            }

            if (!String.IsNullOrWhiteSpace(this.ResourceSecond))
            {
                uriBuilder.Path += '/' + this.ResourceSecond;
            }

            IDictionary<string, string> queryPairs = new Dictionary<string, string>();

            string filterQuery = this.CreateFilterQuery();
            if (!String.IsNullOrWhiteSpace(filterQuery))
            {
                queryPairs["$filter"] = filterQuery;
            }

            queryPairs["api-version"] = this.ApiVersion;

            uriBuilder.Query = ConvertQueryCollection(queryPairs);
            uriBuilder.Port = -1;
            return uriBuilder.ToString();
        }

        private static string ConvertQueryCollection(IDictionary<string,string> queryPairs)
        {
            if (queryPairs == null || queryPairs.Count == 0)
            {
                return null;
            }

            StringBuilder stringBuilder = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in queryPairs)
            {
                if (stringBuilder.Length > 0)
                {
                    stringBuilder.Append(@"&");
                }

                stringBuilder.AppendFormat("{0}={1}", pair.Key, pair.Value);
            }

            return stringBuilder.ToString();
        }

        private string CreateFilterQuery()
        {
            const string LogicalOperatorFormat = @" {0} ";
            const string AnyEqString = @"{0}/any(p:p {1} '{2}')";
            const string FunctionOperator = @"{0}({1},'{2}')";
            const string OperatorForStrings = @"{0} {1} '{2}'";
            const string OperatorForGuids = @"{0} {1} guid'{2}'";
            const string OperatorForOthers = @"{0} {1} {2}";
            StringBuilder filterQueryBuilder = new StringBuilder();
            foreach (GraphApiUrlFilterComponent filterComponent in this.filterComponents)
            {
                string andOr = filterComponent.LogicalOperator;
                string op = filterComponent.ComparisonOperator;
                string propertyName = filterComponent.PropertyName;
                string value = filterComponent.Value;
                GraphApiProperty property = GraphApiEntityType.Users.Properties.Single(p => p.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase));

                if (filterQueryBuilder.Length > 0)
                {
                    filterQueryBuilder.AppendFormat(LogicalOperatorFormat, andOr);
                }

                if (op.Equals(Names.StartsWithOperator, StringComparison.OrdinalIgnoreCase))
                {
                    filterQueryBuilder.AppendFormat(FunctionOperator, Names.StartsWithOperator, propertyName, value);
                }
                else if (op.Equals(Names.AnyEqualsOperator, StringComparison.OrdinalIgnoreCase))
                {
                    filterQueryBuilder.AppendFormat(AnyEqString, propertyName, Names.EqualToOperator, value);
                }
                else if (property.Type == typeof(Guid))
                {
                    filterQueryBuilder.AppendFormat(OperatorForGuids, propertyName, op, value);
                }
                else if (property.Type == typeof(bool) || property.Type == typeof(int))
                {
                    filterQueryBuilder.AppendFormat(OperatorForOthers, propertyName, op, value);
                }
                else
                {
                    filterQueryBuilder.AppendFormat(OperatorForStrings, propertyName, op, value);
                }
            }

            return filterQueryBuilder.ToString();
        }
    }
}
