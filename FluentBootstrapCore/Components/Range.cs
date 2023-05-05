using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using System.Globalization;

namespace FluentBootstrapCore.Components
{
    public class Range : InputComponent, IRange
    {
        public int Min { get; set; }
        public int Max { get; set; }
        public double Step { get; set; }

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
