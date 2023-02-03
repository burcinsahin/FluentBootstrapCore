using FBootstrapCoreMvc.Enums;
using System.Globalization;

namespace FBootstrapCoreMvc.Components
{
    public class Range : InputComponent
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Step { get; internal set; }

        public Range() 
            : base(FormInputType.Range, Css.FormRange)
        {
        }

        protected override void PreBuild()
        {
            if (Min > 0)
                MergeAttribute("min", Min);
            if (Max > 0)
                MergeAttribute("max", Max);
            if (Step > 0)
                MergeAttribute("step", Step.ToString(CultureInfo.InvariantCulture));
            base.PreBuild();
        }
    }
}
