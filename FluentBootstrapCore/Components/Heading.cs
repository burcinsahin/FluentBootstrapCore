using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Heading(byte size) : BootstrapComponent($"h{size}"),
        ICanHaveBadge
    {
        public Badge? Badge { get; set; }

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
