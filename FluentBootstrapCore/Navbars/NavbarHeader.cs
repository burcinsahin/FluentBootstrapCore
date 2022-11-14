using System.IO;

namespace FluentBootstrapCore.Navbars
{
    public class NavbarHeader : NavbarSection,
        ICanCreate<NavbarToggle>,
        ICanCreate<Brand>
    {
        public bool HasToggle { get; set; }

        internal NavbarHeader(BootstrapHelper helper)
            : base(helper, "div"/*, Css.NavbarHeader*/)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            Navbar navbar = GetComponent<Navbar>();
            if (navbar != null)
            {
                navbar.HasHeader = true;
            }

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!HasToggle)
            {
                GetHelper().NavbarToggle().Component.StartAndFinish(writer);
            }

            base.OnFinish(writer);
        }
    }
}
