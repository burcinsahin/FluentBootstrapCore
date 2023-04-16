using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Pagination : BootstrapComponent,
        ICanCreate<PageItem>
    {
        public Pagination()
            : base("ul", Css.Pagination)
        {
        }

        public Pagination AddPageItem(string? href, object? content, bool active = false, bool disabled = false)
        {
            var pageItem = new PageItem().SetLink(href, content).SetActive(active).SetDisabled(disabled);
            AddChild(pageItem);
            return this;
        }

        public Pagination JustifyContent(JustifyContent justifyContent)
        {
            AddCss(justifyContent.GetCssDescription());
            return this;
        }
    }
}
