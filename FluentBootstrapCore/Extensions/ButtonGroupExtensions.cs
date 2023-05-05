using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class ButtonGroupExtensions
    {
        public static BootstrapContent<ButtonGroup> ButtonGroup<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<ButtonGroup>
        {
            var buttonGroup = new ButtonGroup();
            return new BootstrapContent<ButtonGroup>(builder.HtmlHelper, buttonGroup);
        }

        public static BootstrapContent<Button> Button(this ComponentBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new Button
            {
                Content = content
            };
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }

        public static BootstrapContent<LinkButton> LinkButton(this ComponentBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new LinkButton
            {
                Content = content
            };
            return new BootstrapContent<LinkButton>(builder.HtmlHelper, button);
        }

        public static BootstrapContent<Button> DropdownToggle(this ComponentBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new Button
            {
                Content = content
            };
            button.AddCss(Css.DropdownToggle);
            button.MergeAttribute("data-bs-toggle", "dropdown");
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }

        public static CompositeContent<CheckButton> CheckButton(this ComponentBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new CheckButton
            {
                Content = content
            };
            return new CompositeContent<CheckButton>(builder.HtmlHelper, button);
        }

        public static CompositeContent<CheckButton> RadioButton(this ComponentBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new CheckButton
            {
                Content = content,
                Radio = true
            };
            return new CompositeContent<CheckButton>(builder.HtmlHelper, button);
        }

        public static BootstrapContent<ButtonGroup> Size(this BootstrapContent<ButtonGroup> content, ButtonGroupSize size)
        {
            content.Component.Size = size;
            return content;
        }

        public static BootstrapContent<ButtonGroup> Vertical(this BootstrapContent<ButtonGroup> content)
        {
            content.Component.Vertical = true;
            return content;
        }

        public static CompositeContent<TComponent> Checked<TComponent>(this CompositeContent<TComponent> content, bool @checked = true)
            where TComponent : HtmlComponent, ICanBeChecked
        {
            content.Component.Checked = @checked;
            return content;
        }

        public static CompositeContent<TComponent> Name<TComponent>(this CompositeContent<TComponent> content, string name)
            where TComponent : HtmlComponent, ICanHaveName
        {
            content.Component.Name = name;
            return content;
        }

        public static CompositeContent<TComponent> Outline<TComponent>(this CompositeContent<TComponent> content, ButtonOutlineState state)
            where TComponent : HtmlComponent, IButtonOutlineState
        {
            content.Component.OutlineState = state;
            return content;
        }

        public static CompositeContent<TComponent> State<TComponent>(this CompositeContent<TComponent> content, ButtonState state)
            where TComponent : HtmlComponent, IButtonState
        {
            content.Component.ButtonState = state;
            return content;
        }

        public static CompositeContent<TComponent> Disabled<TComponent>(this CompositeContent<TComponent> content)
            where TComponent : HtmlComponent, ICanBeDisabled
        {
            content.Component.Disabled = true;
            return content;
        }
    }
}