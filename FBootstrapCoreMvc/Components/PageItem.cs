using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class PageItem : HtmlComponent
    {
        private Link _link;

        public PageItem()
            : base("li", Css.PageItem)
        {
            _link = new Link();
            _link.AddCss(Css.PageLink);
        }

        protected override void Initialize()
        {
            AddChild(_link);
            base.Initialize();
        }

        protected internal PageItem SetLink(string? href, object? content)
        {
            _link.SetHref(href).SetContent(content);
            return this;
        }

        public PageItem SetActive(bool active = true)
        {
            if (active)
                AddCss(Css.Active);

            return this;
        }

        public PageItem SetDisabled(bool disabled = true)
        {
            if (disabled)
                AddCss(Css.Disabled);

            return this;
        }
    }
}