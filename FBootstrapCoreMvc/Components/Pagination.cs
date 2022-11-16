using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Pagination : Component<Pagination>,
        ICanCreate<PageItem>
    {
        public Pagination(IHtmlHelper helper)
            : base(helper, "ul", Css.Pagination)
        {
        }

        public Pagination AddPageItem(string? href, object? content, bool active = false, bool disabled = false)
        {
            var pageItem = new PageItem(_helper).SetLink(href, content).SetActive(active).SetDisabled(disabled);

            InnerHtml.AppendHtml(pageItem);
            return this;
        }

        public Pagination JustifyContent(JustifyContent justifyContent)
        {
            return AddCss(justifyContent.GetCssDescription());
        }
    }
}
