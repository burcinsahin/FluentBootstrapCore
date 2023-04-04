using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public interface IUtilityOptions
    {
        IEnumerable<string> GetCssList();
        Dictionary<string, object>? GetStyles();
    }
}