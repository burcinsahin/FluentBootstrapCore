using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class PageItem : Component<PageItem>
    {
        private Link _link;

        public PageItem(IHtmlHelper helper)
            : base(helper, "li", Css.PageItem)
        {
            _link = new Link(_helper).AddCss(Css.PageLink);
        }

        public PageItem SetLink(string? href, object? content)
        {
            _link.SetHref(href).SetContent(content);
            AppendContent(_link);
            return this;
        }

        public PageItem SetActive(bool active)
        {
            if (active)
                AddCss(Css.Active);

            return this;
        }

        public PageItem SetDisabled(bool disabled)
        {
            if (disabled)
                AddCss(Css.Disabled);

            return this;
        }
    }
}