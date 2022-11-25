using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Button : HtmlComponent,
        IHaveButtonExtensions, ICanHaveName
    {
        private Icon? _icon;
        public Button(ButtonState buttonState = ButtonState.Primary, object? content = null)
            : base("button", Css.Btn)
        {
            Content = content;
            AddCss(buttonState.GetCssDescription());
        }

        protected override void Initialize()
        {
            if (_icon != null)
            {
                AddChild(_icon, ChildType.Header);
            }
            base.Initialize();
        }

        protected internal void SetType(ButtonType type = ButtonType.Button)
        {
            MergeAttribute("type", type.GetCssDescription());
        }

        protected internal void SetValue(object? value)
        {
            MergeAttribute("value", value);
        }

        protected internal void SetIcon(IconType icon)
        {
            _icon = new Icon(icon);
        }
    }
}