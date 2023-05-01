using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
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
