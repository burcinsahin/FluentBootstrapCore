using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class InteractionOptions : UtilityOptions
    {
        public UserSelect? UserSelect { get; set; }
        public PointerEvent? PointerEvent { get; set; }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            if (UserSelect.HasValue)
                cssList.Add(UserSelect.GetCssDescription());
            if (PointerEvent.HasValue)
                cssList.Add(PointerEvent.GetCssDescription());
            return cssList;
        }
    }
}