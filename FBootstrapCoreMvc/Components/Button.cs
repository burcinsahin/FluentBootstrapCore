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
        public string? Badge { get; set; }
        public bool PositionBadge { get; set; }

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
            if (Badge != null)
            {
                var badge = new Badge() { Content = Badge };
                badge.AddCss(Css.TextBgSecondary);
                if (PositionBadge)
                {
                    AddCss(Css.PositionRelative);
                    badge.AddCss(Css.PositionAbsolute, Css.Top0, Css.Start100, Css.TranslateMiddle, Css.BgDanger);
                    if (Badge == string.Empty)
                    {
                        badge.AddCss(Css.P2, Css.Border, Css.BorderLight, Css.RoundedCircle);
                        badge.RemoveCss(Css.Badge);
                    }
                    else
                        badge.AddCss(Css.RoundedPill);
                }
                AddChild(badge);
            }
            base.PreBuild();
        }
    }
}