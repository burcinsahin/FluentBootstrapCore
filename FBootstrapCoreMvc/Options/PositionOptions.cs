using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class PositionOptions : UtilityOptions
    {
        public Position? Position { get; set; }
        public Absolute? Absolute { get; set; }
        public Translate? Translate { get; set; }
        public override IEnumerable<string> GetCssList()
        {
            if (Absolute.HasValue)
                Position = Enums.Position.Absolute;

            var cssList = new List<string>();

            if (Position.HasValue)
                cssList.Add(Position.GetCssDescription());
            if (Absolute.HasValue)
                cssList.Add(Absolute.GetCssDescription());
            if (Translate.HasValue)
                cssList.Add(Translate.GetCssDescription());

            return cssList;
        }
    }
}
