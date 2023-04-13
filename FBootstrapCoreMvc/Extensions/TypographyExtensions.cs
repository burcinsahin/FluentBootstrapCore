using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FBootstrapCoreMvc.Extensions
{
    public static class TypographyExtensions
    {
        #region Dropdown
        public static BootstrapContent<DropdownMenu> DropdownMenu<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<DropdownMenu>
        {
            var dropdownMenu = new DropdownMenu();
            return new BootstrapContent<DropdownMenu>(builder.HtmlHelper, dropdownMenu);
        }

        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this BootstrapBuilder<TComponent> builder, string? text, string? href)
            where TComponent : SingleComponent, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem
            {
                Content = text,
                Href = href
            };
            return new BootstrapContent<DropdownItem>(builder.HtmlHelper, dropdownItem);
        }

        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this BootstrapBuilder<TComponent> builder, string? text, string action, string controller, object? routeValues = null)
            where TComponent : SingleComponent, ICanCreate<DropdownItem>
        {
            var url = builder.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            var dropdownItem = new DropdownItem
            {
                Content = text,
                Href = url
            };
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

        public static BootstrapContent<Container> AlignText(this BootstrapContent<Container> content, TextAlign alignment)
        {
            content.Component.AddCss(alignment.GetCssDescription());
            return content;
        }

        #region Image
        public static BootstrapContent<Image> Fluid(this BootstrapContent<Image> content)
        {
            content.Component.Fluid = true;
            return content;
        }

        public static BootstrapContent<Image> Thumbnail(this BootstrapContent<Image> content)
        {
            content.Component.Thumbnail = true;
            return content;
        } 
        #endregion
    }
}
