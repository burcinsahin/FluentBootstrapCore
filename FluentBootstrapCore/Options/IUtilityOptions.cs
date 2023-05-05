using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public interface IUtilityOptions
    {
        IEnumerable<string> GetCssList();
        Dictionary<string, object>? GetStyles();
    }
}