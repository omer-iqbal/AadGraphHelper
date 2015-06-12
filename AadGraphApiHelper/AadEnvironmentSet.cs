using System.Collections.Generic;

namespace AadGraphApiHelper
{
    internal class AadEnvironmentSet : SortedSet<AadEnvironment>
    {
        public AadEnvironmentSet()
        {
            this.Add(AadEnvironment.Production);
            this.Add(AadEnvironment.PreProduction);
        }
    }
}
