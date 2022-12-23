using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Extensions
{
    public static class TypographyExtensions
    {
        //public static BootstrapContent<Heading> Heading(this IBootstrapHelper bootstrapHelper, byte size = 1, object? content = null)
        //{
        //    if (size < 1) size = 1;
        //    else if (size > 6) size = 6;

        //    var heading = new Heading(size);
        //    heading.AppendContent(content);
        //    return new BootstrapContent<Heading>(bootstrapHelper.HtmlHelper, heading);
        //}

        //public static BootstrapContent<Heading> Heading1(this IBootstrapHelper bootstrapHelper, object? content = null)
        //{
        //    return bootstrapHelper.Heading(1, content);
        //}

        public static BootstrapContent<Icon> Icon(this IBootstrapHelper bootstrapHelper, IconType iconType, object? content = null)
        {
            var icon = new Icon(iconType);
            icon.AppendContent(content);
            return new BootstrapContent<Icon>(bootstrapHelper.HtmlHelper, icon);
        }

        #region Dropdown
        public static BootstrapContent<DropdownMenu> DropdownMenu<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : HtmlComponent, ICanCreate<DropdownMenu>
        {
            var dropdownMenu = new DropdownMenu();
            return new BootstrapContent<DropdownMenu>(builder.HtmlHelper, dropdownMenu);
        }

        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this BootstrapBuilder<TComponent> builder, string? text, string? href)
            where TComponent : HtmlComponent, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem(text);
            dropdownItem.SetHref(href);
            return new BootstrapContent<DropdownItem>(builder.HtmlHelper, dropdownItem);
        }

        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this BootstrapBuilder<TComponent> builder, string? text, string action, string controller, object? routeValues = null)
            where TComponent : HtmlComponent, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem(text);
            var url = builder.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            dropdownItem.SetHref(url);
            return new BootstrapContent<DropdownItem>(builder.HtmlHelper, dropdownItem);
        }

        public static BootstrapContent<DropdownMenu> Dark(this BootstrapContent<DropdownMenu> bootstrapContent)
        {
            bootstrapContent.Component.AddCss(Css.DropdownMenuDark);
            return bootstrapContent;
        }
        #endregion

        public static BootstrapContent<ListItem> ListItem<TComponent>(this BootstrapBuilder<TComponent> builder, object? content = null)
            where TComponent : List
        {
            var listItem = new ListItem() { Content = content };

            if (builder.Component.Type == ListType.Inline)
                listItem.Inline = true;

            return new BootstrapContent<ListItem>(builder.HtmlHelper, listItem);
        }

        public static BootstrapContent<Container> SetAlignment(this BootstrapContent<Container> content, TextAlignment alignment)
        {
            content.Component.AddCss(alignment.GetCssDescription());
            return content;
        }
    }
}
