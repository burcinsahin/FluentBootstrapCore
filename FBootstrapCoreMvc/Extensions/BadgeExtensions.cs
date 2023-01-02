using FBootstrapCoreMvc.Components;

namespace FBootstrapCoreMvc.Extensions
{
    public static class BadgeExtensions
    {
        public static BootstrapContent<Badge> RoundedPill(this BootstrapContent<Badge> content)
        {
            content.Component.AddCss(Css.RoundedPill);
            return content;
        }
    }
}
