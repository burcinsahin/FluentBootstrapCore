using FluentBootstrapCore.Components;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class ListGroupExtensions
    {
        public static BootstrapContent<ListGroupItem> ListGroupItem<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : BootstrapComponent, ICanCreate<ListGroupItem>
        {
            var listGroupItem = new ListGroupItem();
            return new BootstrapContent<ListGroupItem>(builder.HtmlHelper, listGroupItem);
        }
    }
}
