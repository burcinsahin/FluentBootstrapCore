using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ButtonGroupExtensions
    {
        public static BootstrapContent<Button> Button(this BootstrapBuilder<ButtonGroup> builder, object? content =null)
        {
            var button = new Button
            {
                Content = content
            };
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }

        public static BootstrapContent<LinkButton> LinkButton(this BootstrapBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new LinkButton
            {
                Content = content
            };
            return new BootstrapContent<LinkButton>(builder.HtmlHelper, button);
        }

        public static CompositeContent<CheckButton> CheckButton(this BootstrapBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new CheckButton
            {
                Content = content
            };
            return new CompositeContent<CheckButton>(builder.HtmlHelper, button);
        }

        public static CompositeContent<CheckButton> RadioButton(this BootstrapBuilder<ButtonGroup> builder, object? content = null)
        {
            var button = new CheckButton
            {
                Content = content,
                Radio = true
            };
            return new CompositeContent<CheckButton>(builder.HtmlHelper, button);
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
    }
}
