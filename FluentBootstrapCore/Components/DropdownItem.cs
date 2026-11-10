using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Dropdown menu item: &lt;li&gt;&lt;a class="dropdown-item"&gt; or, with <see cref="AsButton"/>,
    /// &lt;li&gt;&lt;button class="dropdown-item"&gt;.
    /// </summary>
    public class DropdownItem : BootstrapComponent,
        ILink,
        ICanBeActive,
        ICanBeDisabled
    {
        public string? Href { get; set; }
        public LinkTarget? Target { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        /// <summary>
        /// Renders a &lt;button type="button"&gt; instead of a link.
        /// </summary>
        public bool AsButton { get; set; }

        public DropdownItem()
            : base("li")
        {
        }

        protected override void PreBuild()
        {
            SingleComponent item;
            if (AsButton)
            {
                item = new HtmlElement("button", Css.DropdownItem) { Content = Content };
                item.MergeAttribute("type", "button");
                if (Disabled)
                    item.MergeAttribute("disabled");
            }
            else
            {
                var link = new Link
                {
                    Content = Content,
                    Href = Href,
                    Target = Target
                };
                link.AddCss(Css.DropdownItem);
                if (Disabled)
                    link.AddCss(Css.Disabled);
                item = link;
            }

            if (Active)
            {
                item.AddCss(Css.Active);
                item.MergeAttribute("aria-current", true);
            }

            AddChild(item);
            Content = null;
            base.PreBuild();
        }
    }
}
