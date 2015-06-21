using System;
using System.Collections.Generic;

namespace AadGraphApiHelper
{
    internal class GraphApiUrlFilterComponent
    {
        private static string[] allowedLogicalOperators = { Names.AndOperator, Names.OrOperator };

        public static string[] AllowedLogicalOperators
        {
            get { return allowedLogicalOperators; } 
        }

        public string LogicalOperator { get; set; }

        public string PropertyName { get; set; }

        public string ComparisonOperator { get; set; }

        public string Value { get; set; }
    }
}
