using System;
using System.Collections.Generic;
using System.Text;

namespace AadGraphApiHelper
{
    internal class MSGraphApiUrlFormatter : IGraphApiUrlFormatter
    {
        public string FormatUrl(GraphApiUrlBuilder builder)
        {
            if (builder.Environment == null ||
                builder.TenantCredential == null ||
                String.IsNullOrWhiteSpace(builder.ResourceFirst) ||
                String.IsNullOrWhiteSpace(builder.ApiVersion))
            {
                return null;
            }

            UriBuilder uriBuilder = new UriBuilder(builder.Environment.GraphResourceUrl);
            uriBuilder.Path = builder.ApiVersion + '/' + builder.ResourceFirst;
            if (!String.IsNullOrWhiteSpace(builder.ResourceId))
            {
                uriBuilder.Path += '/' + builder.ResourceId;
            }

            if (!String.IsNullOrWhiteSpace(builder.ResourceSecond))
            {
                uriBuilder.Path += '/' + builder.ResourceSecond;
            }

            IDictionary<string, string> queryPairs = new Dictionary<string, string>();

            string filterQuery = this.CreateFilterQuery(builder);
            if (!String.IsNullOrWhiteSpace(filterQuery))
            {
                queryPairs["$filter"] = filterQuery;
            }

            uriBuilder.Query = ConvertQueryCollection(queryPairs);
            uriBuilder.Port = -1;
            return uriBuilder.ToString();
        }

        private static string ConvertQueryCollection(IDictionary<string, string> queryPairs)
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

        private string CreateFilterQuery(GraphApiUrlBuilder builder)
        {
            const string LogicalOperatorFormat = @" {0} ";
            const string AnyEqString = @"{0}/any(p:p {1} '{2}')";
            const string FunctionOperator = @"{0}({1},'{2}')";
            const string OperatorForStrings = @"{0} {1} '{2}'";
            const string OperatorForGuids = @"{0} {1} '{2}'";
            const string OperatorForOthers = @"{0} {1} {2}";
            StringBuilder filterQueryBuilder = new StringBuilder();
            foreach (GraphApiUrlFilterComponent filterComponent in builder.FilterComponents)
            {
                string andOr = filterComponent.LogicalOperator;
                string op = filterComponent.ComparisonOperator;
                GraphApiProperty property = filterComponent.Property;
                string value = filterComponent.Value;

                if (filterQueryBuilder.Length > 0)
                {
                    filterQueryBuilder.AppendFormat(LogicalOperatorFormat, andOr);
                }

                if (op.Equals(Names.StartsWithOperator, StringComparison.OrdinalIgnoreCase))
                {
                    filterQueryBuilder.AppendFormat(FunctionOperator, Names.StartsWithOperator, property.Name, value);
                }
                else if (op.Equals(Names.AnyEqualsOperator, StringComparison.OrdinalIgnoreCase))
                {
                    filterQueryBuilder.AppendFormat(AnyEqString, property.Name, Names.EqualToOperator, value);
                }
                else if (property.Type == typeof(Guid))
                {
                    filterQueryBuilder.AppendFormat(OperatorForGuids, property.Name, op, value);
                }
                else if (property.Type == typeof(bool) || property.Type == typeof(int))
                {
                    filterQueryBuilder.AppendFormat(OperatorForOthers, property.Name, op, value);
                }
                else
                {
                    filterQueryBuilder.AppendFormat(OperatorForStrings, property.Name, op, value);
                }
            }

            return filterQueryBuilder.ToString();
        }
    }
}
