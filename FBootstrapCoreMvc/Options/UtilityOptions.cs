using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public abstract class UtilityOptions : IUtilityOptions
    {
        public abstract IEnumerable<string> GetCssList();

        public virtual Dictionary<string, object>? GetStyles() => null;
    }
}
