using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Button : HtmlComponent,
        IHaveButtonExtensions,
        ICanHaveName,
        ICanHaveValue
    {
        public IconType? IconType { get; set; }
        public ButtonState ButtonState { get; set; }
        public ButtonType ButtonType { get; set; }

        public Button(object? content = null)
            : base("button", Css.Btn)
        {
            Content = content;
            ButtonState = ButtonState.Primary;
        }

        protected override void PreBuild()
        {
            AddCss(ButtonState.GetCssDescription());
            MergeAttribute("type", ButtonType.GetCssDescription());

            if (IconType.HasValue)
            {
                var icon = new Icon(IconType.Value);
                AddChild(icon, ChildLocation.Header);
            }
            base.PreBuild();
        }
    }
}