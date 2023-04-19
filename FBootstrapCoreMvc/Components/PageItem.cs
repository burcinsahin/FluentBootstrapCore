using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class PageItem : BootstrapComponent, ICanBeActive, ICanBeDisabled
    {
        protected internal Link Link { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        public PageItem()
            : base("li", Css.PageItem)
        {
            Link = new Link();
        }

        protected override void PreBuild()
        {
            if (Active)
                AddCss(Css.Active);
            if (Disabled)
                AddCss(Css.Disabled);

            Link.AddCss(Css.PageLink);

            AddChild(Link);

            base.PreBuild();
        }
    }
}