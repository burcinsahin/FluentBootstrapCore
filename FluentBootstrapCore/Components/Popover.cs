using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using FluentBootstrapCore.Options;

namespace FluentBootstrapCore.Components
{
    public class Popover : HtmlComponent, IPopover
    {
        public object? Content { get; set; }
        public string? CustomClass { get; set; }
        public bool Disabled { get; set; }
        public string? PopoverContent { get; set; }
        public string? PopoverTitle { get; set; }
        public PopperDirection? Direction { get; set; }
        public string? Container { get; set; }
        public ButtonState? State { get; set; }
        public bool Dismissable { get; set; }
        public ButtonSize? Size { get; set; }


        private readonly bool _isLink;

        public Popover(bool isLink = false)
        {
            _isLink = isLink;
        }

        public override string ToHtml()
        {
            ButtonComponent popover;

            if (_isLink)
                popover = new LinkButton();
            else
                popover = new Button();

            popover.Content = Content;

            if (State.HasValue)
                popover.ButtonState = State.Value;

            if (Size.HasValue)
                popover.AddCss(Size.GetCssDescription());

            if (Disabled)//TODO: declare popover as HtmlElement?
            {
                var span = new HtmlElement("span");
                span.MergeAttribute("tabindex", 0);

                span.UtilityOptions.Add(new DisplayOptions()
                {
                    Display = new EnumList<Display> { { Breakpoint.Default, Display.InlineBlock } }
                });

                span.MergeAttribute("data-bs-toggle", "popover");
                span.MergeAttribute("data-bs-trigger", "hover focus");
                span.MergeAttribute("data-bs-content", PopoverContent);

                if (PopoverTitle != null)
                    span.MergeAttribute("data-bs-title", PopoverTitle);

                popover.Disabled = true;
                span.Content = popover;
                return span.ToHtml();
            }

            popover.MergeAttribute("tabindex", 0);
            popover.MergeAttribute("data-bs-toggle", "popover");
            popover.MergeAttribute("data-bs-content", PopoverContent);

            if (Direction != null)
                popover.MergeAttribute("data-bs-placement", Direction.GetDescription());

            if (CustomClass != null)
                popover.MergeAttribute("data-bs-custom-class", CustomClass);

            if (PopoverTitle != null)
                popover.MergeAttribute("data-bs-title", PopoverTitle);

            if (Dismissable)
                popover.MergeAttribute("data-bs-trigger", "focus");

            return popover.ToHtml();
        }
    }
}
