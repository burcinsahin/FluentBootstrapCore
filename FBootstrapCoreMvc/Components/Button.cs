using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Button : BaseButton, 
        ICanHaveValue, 
        ICanHaveName
    {
        public Button(object? content = null)
            : base("button")
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            MergeAttribute("type", ButtonType.GetCssDescription());

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