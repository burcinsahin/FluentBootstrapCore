using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Extensions
{
    public static class TypographyExtensions
    {
        #region Dropdown
        public static DropdownMenu DropdownMenu<TComponent>(this HtmlBuilder<TComponent> builder)
            where TComponent : Component<TComponent>, ICanCreate<DropdownMenu>
        {
            var dropdownMenu = new DropdownMenu(builder.HtmlHelper);
            return dropdownMenu;
        }

        public static DropdownItem DropdownItem<TComponent>(this HtmlBuilder<TComponent> builder, string? text, string action, string controller, object? routeValues = null)
            where TComponent : Component<TComponent>, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem(builder.HtmlHelper, text);
            var url = builder.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            dropdownItem.SetHref(url);
            return dropdownItem;
        }
        #endregion

        public static ListItem ListItem<TComponent>(this HtmlBuilder<TComponent> builder, object? content = null)
            where TComponent : Component<TComponent>, ICanCreate<ListItem>
        {
            return new ListItem(builder.HtmlHelper)
                .SetContent(content);
        }

        public static Container SetAlignment(this Container container, TextAlignment alignment) => container.AddCss(alignment.GetCssDescription());
    }
}
