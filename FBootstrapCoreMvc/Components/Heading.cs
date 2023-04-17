using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Heading : BootstrapComponent,
        ICanHaveBadge
    {
        public Badge? Badge { get; set; }

        public Heading(byte size)
            : base($"h{size}")
        {
        }

        protected override void PreBuild()
        {
            if (Badge != null)
            {
                Badge.AddCss(Css.TextBgSecondary);
                AddChild(Badge);
            }
            base.PreBuild();
        }
    }
}
