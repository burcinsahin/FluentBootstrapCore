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
            AppendContent(content);
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

        //public Button SetIcon(IconType icon)
        //{
        //    _icon = new Icon(_helper, icon);
        //    InnerHtml.Clear();
        //    InnerHtml.AppendHtml(_icon);
        //    AppendContent(_content);
        //    return this;
        //}
    }
}