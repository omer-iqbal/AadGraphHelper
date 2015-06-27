using System;
using System.Collections.Generic;

namespace AadGraphApiHelper
{
    internal class GraphApiProperty
    {
        private static IDictionary<Type, string[]> comparisonOperatorByType = new Dictionary<Type, string[]>
        {
            { typeof(string), new[] { Names.StartsWithOperator, Names.EqualToOperator, Names.GreaterThanOrEqualToOperator, Names.LessThanOrEqualToOperator } },
            { typeof(ICollection<string>), new[] { Names.AnyEqualsOperator } },
            { typeof(bool), new[] { Names.EqualToOperator } },
            { typeof(Guid), new[] { Names.EqualToOperator } },
            { typeof(object), new[] { Names.EqualToOperator, Names.GreaterThanOrEqualToOperator, Names.LessThanOrEqualToOperator } }
        };

        public string Name { get; private set; }

        public Type Type { get; private set; }

        public bool Filterable { get; private set; }

        internal GraphApiProperty(string name, Type type, bool filterable)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException(StringResources.NameCannotBeNullOrWhiteSpace, "name");
            }

            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            this.Name = name;
            this.Type = type;
            this.Filterable = filterable;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return this.Name;
        }

        public string[] GetAllowedComparisonOperators()
        {
            string[] operators;
            if (comparisonOperatorByType.TryGetValue(this.Type, out operators))
            {
                return operators;
            }

            return comparisonOperatorByType[typeof(object)];
        }
    }
}
