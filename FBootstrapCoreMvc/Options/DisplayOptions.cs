using FBootstrapCoreMvc.Enums;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class DisplayOptions
    {
        public Dictionary<Breakpoint, Display> Display { get; set; }
        public DisplayPrint? DisplayPrint { get; set; }
        public DisplayOptions()
        {
            Display = new Dictionary<Breakpoint, Display>();
        }
    }
}