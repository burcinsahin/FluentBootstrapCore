using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FluentBootstrapCore.Extensions
{
    public static class DropdownExtensions
    {
        #region Container
        /// <summary>
        /// Opens the menu above the toggle (<c>.dropup</c>).
        /// </summary>
        public static BootstrapContent<TComponent> Dropup<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, IDropdownContainer
        {
            bootstrapContent.Component.Direction = DropdownDirection.Up;
            return bootstrapContent;
        }

        /// <summary>
        /// Opens the menu at the right of the toggle (<c>.dropend</c>).
        /// </summary>
        public static BootstrapContent<TComponent> Dropend<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, IDropdownContainer
        {
            bootstrapContent.Component.Direction = DropdownDirection.End;
            return bootstrapContent;
        }

        /// <summary>
        /// Opens the menu at the left of the toggle (<c>.dropstart</c>).
        /// </summary>
        public static BootstrapContent<TComponent> Dropstart<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : BootstrapComponent, IDropdownContainer
        {
            bootstrapContent.Component.Direction = DropdownDirection.Start;
            return bootstrapContent;
        }

        /// <summary>
        /// Centers the menu below (<c>.dropdown-center</c>) or above (<c>.dropup-center</c>, combined with <see cref="Dropup{TComponent}"/>) the toggle.
        /// </summary>
        public static BootstrapContent<TComponent> Centered<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool value = true)
            where TComponent : BootstrapComponent, IDropdownContainer
        {
            bootstrapContent.Component.Centered = value;
            return bootstrapContent;
        }

        public static BootstrapContent<LinkButton> LinkButton<TComponent>(this ComponentBuilder<TComponent> builder, object? content = null, string href = "#")
            where TComponent : BootstrapComponent, ICanCreate<LinkButton>
        {
            var linkButton = new LinkButton(content)
            {
                Href = href
            };
            return new BootstrapContent<LinkButton>(builder.HtmlHelper, linkButton);
        }
        #endregion

        #region Toggle
        /// <summary>
        /// Sets <c>data-bs-auto-close</c> on the toggle.
        /// </summary>
        public static BootstrapContent<TComponent> DropdownAutoClose<TComponent>(this BootstrapContent<TComponent> bootstrapContent, DropdownAutoClose autoClose)
            where TComponent : ButtonComponent
        {
            bootstrapContent.Component.MergeAttribute("data-bs-auto-close", autoClose.GetCssDescription(), true);
            return bootstrapContent;
        }

        /// <summary>
        /// Sets <c>data-bs-offset</c> (skidding, distance) on the toggle.
        /// </summary>
        public static BootstrapContent<TComponent> DropdownOffset<TComponent>(this BootstrapContent<TComponent> bootstrapContent, int skidding, int distance)
            where TComponent : ButtonComponent
        {
            bootstrapContent.Component.MergeAttribute("data-bs-offset", $"{skidding},{distance}", true);
            return bootstrapContent;
        }

        /// <summary>
        /// Sets <c>data-bs-reference</c> on the toggle.
        /// </summary>
        public static BootstrapContent<TComponent> DropdownReference<TComponent>(this BootstrapContent<TComponent> bootstrapContent, DropdownReference reference)
            where TComponent : ButtonComponent
        {
            bootstrapContent.Component.MergeAttribute("data-bs-reference", reference.GetCssDescription(), true);
            return bootstrapContent;
        }

        /// <summary>
        /// Disables Popper's dynamic positioning (<c>data-bs-display="static"</c>), required for responsive menu alignment.
        /// </summary>
        public static BootstrapContent<TComponent> DropdownStatic<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : ButtonComponent
        {
            bootstrapContent.Component.MergeAttribute("data-bs-display", "static", true);
            return bootstrapContent;
        }
        #endregion

        #region Menu
        public static BootstrapContent<DropdownMenu> DropdownMenu<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<DropdownMenu>
        {
            var dropdownMenu = new DropdownMenu();
            return new BootstrapContent<DropdownMenu>(builder.HtmlHelper, dropdownMenu);
        }

        public static BootstrapContent<TComponent> Dark<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeDropdownMenu
        {
            bootstrapContent.Component.AddCss(Css.DropdownMenuDark);
            return bootstrapContent;
        }

        /// <summary>
        /// Right aligns the menu (<c>.dropdown-menu-end</c>), or from the given breakpoint up (<c>.dropdown-menu-{bp}-end</c>).
        /// Responsive alignment requires <see cref="DropdownStatic{TComponent}"/> on the toggle.
        /// </summary>
        public static BootstrapContent<TComponent> AlignEnd<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, ICanBeDropdownMenu
        {
            var cssClass = breakpoint == Breakpoint.Default
                ? Css.DropdownMenuEnd
                : $"dropdown-menu{breakpoint.GetHyphenatedDescription()}-end";
            bootstrapContent.Component.AddCss(cssClass);
            return bootstrapContent;
        }

        /// <summary>
        /// Left aligns the menu (<c>.dropdown-menu-{bp}-start</c>) from the given breakpoint up.
        /// </summary>
        public static BootstrapContent<TComponent> AlignStart<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Breakpoint breakpoint = Breakpoint.Default)
            where TComponent : SingleComponent, ICanBeDropdownMenu
        {
            bootstrapContent.Component.AddCss($"dropdown-menu{breakpoint.GetHyphenatedDescription()}-start");
            return bootstrapContent;
        }

        /// <summary>
        /// Turns the element (e.g. a div or a form) into a dropdown menu (<c>.dropdown-menu</c>).
        /// </summary>
        public static BootstrapContent<TComponent> AsDropdownMenu<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeDropdownMenu
        {
            bootstrapContent.Component.AddCss(Css.DropdownMenu);
            return bootstrapContent;
        }

        /// <summary>
        /// Turns the element (e.g. a link) into a dropdown menu item (<c>.dropdown-item</c>) to be used directly inside a non-list dropdown menu.
        /// </summary>
        public static BootstrapContent<TComponent> AsDropdownItem<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeDropdownItem
        {
            bootstrapContent.Component.AddCss(Css.DropdownItem);
            return bootstrapContent;
        }

        /// <summary>
        /// Turns the element into a dropdown divider (<c>.dropdown-divider</c>) to be used directly inside a non-list dropdown menu.
        /// </summary>
        public static BootstrapContent<TComponent> AsDropdownDivider<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeDropdownDivider
        {
            bootstrapContent.Component.AddCss(Css.DropdownDivider);
            return bootstrapContent;
        }
        #endregion

        #region Items
        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this ComponentBuilder<TComponent> builder, string? text, string? href)
            where TComponent : SingleComponent, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem
            {
                Content = text,
                Href = href
            };
            return new BootstrapContent<DropdownItem>(builder.HtmlHelper, dropdownItem);
        }

        public static BootstrapContent<DropdownItem> DropdownItem<TComponent>(this ComponentBuilder<TComponent> builder, string? text, string action, string controller, object? routeValues = null)
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

        /// <summary>
        /// Menu item rendered as a &lt;button type="button"&gt;.
        /// </summary>
        public static BootstrapContent<DropdownItem> DropdownButtonItem<TComponent>(this ComponentBuilder<TComponent> builder, string? text)
            where TComponent : SingleComponent, ICanCreate<DropdownItem>
        {
            var dropdownItem = new DropdownItem
            {
                Content = text,
                AsButton = true
            };
            return new BootstrapContent<DropdownItem>(builder.HtmlHelper, dropdownItem);
        }

        /// <summary>
        /// Non-interactive menu item (<c>.dropdown-item-text</c>).
        /// </summary>
        public static BootstrapContent<ListItem> DropdownText<TComponent>(this ComponentBuilder<TComponent> builder, string? text)
            where TComponent : DropdownMenu
        {
            var li = new ListItem()
            {
                Content = new HtmlElement("span", Css.DropdownItemText) { Content = text }
            };
            return new BootstrapContent<ListItem>(builder.HtmlHelper, li);
        }

        /// <summary>
        /// Label for a section of menu items (<c>.dropdown-header</c>).
        /// </summary>
        public static BootstrapContent<ListItem> DropdownHeader<TComponent>(this ComponentBuilder<TComponent> builder, string? text)
            where TComponent : DropdownMenu
        {
            var li = new ListItem()
            {
                Content = new HtmlElement("h6", Css.DropdownHeader) { Content = text }
            };
            return new BootstrapContent<ListItem>(builder.HtmlHelper, li);
        }

        public static BootstrapContent<ListItem> Divider<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : DropdownMenu
        {
            var li = new ListItem()
            {
                Content = new HtmlElement("hr", Css.DropdownDivider)
            };
            return new BootstrapContent<ListItem>(builder.HtmlHelper, li);
        }
        #endregion
    }
}
