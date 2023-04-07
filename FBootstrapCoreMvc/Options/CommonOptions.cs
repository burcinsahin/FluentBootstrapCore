using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Options
{
    public class CommonOptions : UtilityOptions
    {
        public EnumList<Order> Order { get; set; }
        public Opacity? Opacity { get; set; }

        public CommonOptions()
        {
            Order = new EnumList<Order>();
        }

        public override IEnumerable<string> GetCssList()
        {
            var cssList = new List<string>();
            cssList.AddRange(Order.GetCssDescriptions());
            if (Opacity.HasValue)
                cssList.Add(Opacity.GetCssDescription());
            return cssList;
        }
    }
}
