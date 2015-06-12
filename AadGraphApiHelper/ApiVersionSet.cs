using System;
using System.Collections.Generic;

namespace AadGraphApiHelper
{
    internal class ApiVersionSet : SortedSet<string>
    {
        internal ApiVersionSet() : base(StringComparer.OrdinalIgnoreCase)
        {
            this.Add(@"1.5");
            this.Add(@"beta");
            this.Add(@"1.22-preview");
            this.Add(@"2013-11-08");
        }
    }
}
