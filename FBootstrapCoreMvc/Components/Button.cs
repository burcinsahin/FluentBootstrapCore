using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Button : Component<Button>,
        IHaveButtonExtensions, ICanHaveName
    {
        private Icon? _icon;
        private object? _content;
        public Button(IHtmlHelper helper, ButtonState buttonState = ButtonState.Primary, object? content = null)
            : base(helper, "button", Css.Btn)
        {
            _content = content;
            AddCssClass(buttonState.GetCssDescription());
            SetContent(content);
        }

        public Button SetType(ButtonType type = ButtonType.Button)
            => AddAttribute("type", type.GetCssDescription());

        public Button SetValue(object? value) => AddAttribute("value", value);

        public Button SetIcon(IconType icon)
        {
            _icon = new Icon(_helper, icon);
            InnerHtml.Clear();
            InnerHtml.AppendHtml(_icon);
            SetContent(_content);
            return this;
        }
    }
}