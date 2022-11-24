using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class LinkButton : HtmlComponent, 
        IHaveButtonExtensions
    {
        private Icon? _icon;
        private object? _content;
        public LinkButton(ButtonState buttonState = ButtonState.Primary, object? content = null)
            : base("a", Css.Btn)
        {
            _content = content;
            MergeAttribute("role", "button");
            AddCss(buttonState.GetCssDescription());
            AppendContent(content);
        }

        public LinkButton SetIcon(IconType icon)
        {
            _icon = new Icon(icon);
            AddChild(_icon);
            AppendContent(_content);
            return this;
        }
    }
}