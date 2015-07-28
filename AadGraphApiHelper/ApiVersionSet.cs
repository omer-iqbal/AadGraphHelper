using System;
using System.Collections.Generic;

namespace AadGraphApiHelper
{
    internal class ApiVersionSet : SortedSet<string>
    {
        internal ApiVersionSet() : base(StringComparer.OrdinalIgnoreCase)
        {
            this.Add(@"1.5");
            this.Add(@"1.6");
            this.Add(@"beta");
        }
    }
}
