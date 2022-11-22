using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Runtime.CompilerServices;

namespace FBootstrapCoreMvc.Extensions
{
    public static class TypographyExtensions
    {
        public static BootstrapContent<Heading> Heading(this IBootstrapHelper bootstrapHelper, byte size = 1, object? content = null)
        {
            if (size < 1) size = 1;
            else if (size > 6) size = 6;

            var heading = new Heading(size);
            heading.AppendContent(content);
            return new BootstrapContent<Heading>(bootstrapHelper.HtmlHelper, heading);
        }

        public static BootstrapContent<Heading> Heading1(this IBootstrapHelper bootstrapHelper, object? content = null)
        {
            return bootstrapHelper.Heading(1, content);
        }

        public static BootstrapContent<Icon> Icon(this IBootstrapHelper bootstrapHelper, IconType iconType, object? content = null)
        {
            var icon = new Icon(iconType);
            icon.AppendContent(content);
            return new BootstrapContent<Icon>(bootstrapHelper.HtmlHelper, icon);
        }

        public static BootstrapContent<Alert> Alert<TModel>(this BootstrapHelper<TModel> bootstrap)
        {
            return new BootstrapContent<Alert>(bootstrap.HtmlHelper, new Alert());
        }

        #region Dropdown
        public static DropdownMenu DropdownMenu<TComponent>(this HtmlBuilder<TComponent> builder)
            where TComponent : Component<TComponent>, ICanCreate<DropdownMenu>
        {
            var dropdownMenu = new DropdownMenu(builder.HtmlHelper);
            return dropdownMenu;
        }

        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this BootstrapBuilder<TComponent> builder, string? text, string action, string controller, object? routeValues = null)
            where TComponent : HtmlComponent, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem(text);
            var url = builder.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            dropdownItem.SetHref(url);
            return new BootstrapContent<DropdownItem>(builder.HtmlHelper, dropdownItem);
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
