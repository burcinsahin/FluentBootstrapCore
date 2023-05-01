using FluentBootstrapCore.Enums;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class FloatOptions : UtilityOptions
    {
        public EnumList<Float> Float { get; set; }

        public FloatOptions()
        {
            Float = new EnumList<Float>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            cssList.AddRange(Float.GetCssDescriptions());
            return cssList;
        }
    }
}