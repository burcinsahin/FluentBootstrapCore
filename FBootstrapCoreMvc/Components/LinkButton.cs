using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class LinkButton : HtmlComponent,
        IHaveButtonExtensions
    {
        public IconType? IconType { get; set; }
        public ButtonState ButtonState { get; set; }
        public ButtonType ButtonType { get; set; }
        public string? Badge { get; set; }
        public bool PositionBadge { get; set; }

        public LinkButton(object? content = null)
            : base("a", Css.Btn)
        {
            Content = content;
            MergeAttribute("role", "button");
            ButtonState = ButtonState.Primary;
        }

        protected override void PreBuild()
        {
            AddCss(ButtonState.GetCssDescription());

            if (IconType.HasValue)
            {
                var icon = new Icon(IconType.Value);
                AddChild(icon, ChildLocation.Header);
            }

            base.PreBuild();
        }
    }
}