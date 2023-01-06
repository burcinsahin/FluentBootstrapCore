using FBootstrapCoreMvc.Components;

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
    }
}
