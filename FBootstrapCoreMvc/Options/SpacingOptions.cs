using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System.Collections.Generic;
using System.Security.Permissions;

namespace FBootstrapCoreMvc.Options
{
    public class SpacingOptions : UtilityOptions
    {
        public Dictionary<(Breakpoint, Margin), sbyte> Margin;
        public Dictionary<(Breakpoint, Padding), sbyte> Padding;
        public EnumList<Gap> Gap { get; set; }
        public SpacingOptions()
        {
            Margin = new Dictionary<(Breakpoint, Margin), sbyte>();
            Padding = new Dictionary<(Breakpoint, Padding), sbyte>();
            Gap = new EnumList<Gap>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();

            foreach (var m in Margin)
            {
                var br = m.Key.Item1;
                var mrg = m.Key.Item2;
                var val = m.Value.Limit<sbyte>(-1, 5);

                cssList.Add($"{mrg.GetCssDescription()}{br.GetHyphenatedDescription()}{(val == -1 ? "-auto" : $"-{val}")}");
            }

            foreach (var p in Padding)
            {
                var br = p.Key.Item1;
                var mrg = p.Key.Item2;
                var val = p.Value.Limit<sbyte>(-1, 5);

                cssList.Add($"{mrg.GetCssDescription()}{br.GetHyphenatedDescription()}{(val == -1 ? "-auto" : $"-{val}")}");
            }

            cssList.AddRange(Gap.GetCssDescriptions());

            return cssList;
        }
    }
}
