using FBootstrapCoreMvc.Enums;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class FloatOptions
    {
        public Dictionary<Breakpoint, Float> Float { get; set; }

        public FloatOptions()
        {
            Float = new Dictionary<Breakpoint, Float>();
        }
    }
}