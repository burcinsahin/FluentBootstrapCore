using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Container : HtmlComponent,
        ICanCreate<GridRow>
    {
        public bool TextCentered { get; set; }

        public Container()
            : base("div", Css.Container)
        {
        }

        protected override void PreBuild()
        {
            if (TextCentered)
                AddCss(Css.TextCenter);
            base.PreBuild();
        }
    }
}
