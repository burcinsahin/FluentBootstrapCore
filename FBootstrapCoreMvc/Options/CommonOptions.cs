using FluentBootstrapCore.Enums;
using System.Collections.Generic;

namespace FluentBootstrapCore.Options
{
    public class CommonOptions : UtilityOptions
    {
        public EnumList<Order> Order { get; set; }
        public Opacity? Opacity { get; set; }
        public Shadow? Shadow { get; set; }
        public Width? Width { get; set; }
        public Height? Height { get; set; }
        public VerticalAlign? VerticalAlign { get; set; }
        public Visibility? Visibility { get; internal set; }

        public CommonOptions()
        {
            Order = new EnumList<Order>();
        }

        public override IEnumerable<string> GetCssList()
        {
            AddCssFor(Order);
            AddCssFor(Opacity);
            AddCssFor(Shadow);
            AddCssFor(Width);
            AddCssFor(Height);
            AddCssFor(VerticalAlign);
            AddCssFor(Visibility);
            return base.GetCssList();
        }
    }
}
