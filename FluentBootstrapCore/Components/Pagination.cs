using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Pagination : BootstrapComponent,
        ICanCreate<PageItem>,
        ISizable<PaginationSize>
    {
        public PaginationSize? Size { get; set; }

        public Pagination()
            : base("ul", Css.Pagination)
        {
        }

        public Pagination AddPageItem(string? href, object? content, bool active = false, bool disabled = false)
        {
            if(Size.HasValue)
                AddCss(Size.GetCssDescription());

            var pageItem = new PageItem();
            pageItem.Link.Href = href;
            pageItem.Link.Content = content;
            pageItem.Active = active;
            pageItem.Disabled = disabled;
            AddChild(pageItem);
            return this;
        }
    }
}
