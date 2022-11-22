using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Container : HtmlComponent,
        ICanCreate<GridRow>
    {
        public Container()
            : base("div", Css.Container)
        {
        }

        protected internal Container TextCenter()
        {
            AddCss(Css.TextCenter);
            return this;
        }
    }
}
