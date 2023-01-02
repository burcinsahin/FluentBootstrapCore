using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Heading : HtmlComponent,
        ICanHaveBadge
    {
        public string? Badge { get; set; }

        public Heading(byte size)
            : base($"h{size}")
        {
        }

        protected override void PreBuild()
        {
            if (Badge != null)
            {
                var badge = new Badge() { Content = Badge };
                badge.AddCss(Css.TextBgSecondary);
                AddChild(badge);
            }
            base.PreBuild();
        }
    }
}
