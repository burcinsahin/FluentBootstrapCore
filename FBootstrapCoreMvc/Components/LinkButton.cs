using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class LinkButton : Component<LinkButton>, IHaveButtonExtensions
    {
        private Icon? _icon;
        private object? _content;
        public LinkButton(IHtmlHelper helper, ButtonState buttonState = ButtonState.Primary, object? content = null)
            : base(helper, "a", Css.Btn)
        {
            _content = content;
            MergeAttribute("role", "button");
            AddCssClass(buttonState.GetCssDescription());
            SetContent(content);
        }

        public LinkButton SetIcon(IconType icon)
        {
            _icon = new Icon(_helper, icon);
            InnerHtml.Clear();
            InnerHtml.AppendHtml(_icon);
            SetContent(_content);
            return this;
        }
    }
}