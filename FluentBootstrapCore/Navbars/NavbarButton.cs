using FluentBootstrapCore.Buttons;
using FluentBootstrapCore.Icons;
using System.IO;

namespace FluentBootstrapCore.Navbars
{
    public class NavbarButton : Tag, IHasIconExtensions, IHasButtonExtensions, IHasButtonStateExtensions,
        IHasDisabledAttribute, IHasTextContent, IHasValueAttribute, INavbarComponent
    {
        internal NavbarButton(BootstrapHelper helper)
            : base(helper, "button", Css.Btn, Css.BtnPrimary/*, Css.NavbarBtn, Css.NavbarLeft*/)
        {
            MergeAttribute("type", "button");
        }

        protected override void OnStart(TextWriter writer)
        {
            // See if we're in a navbar
            if (GetComponent<Navbar>() != null)
            {
                // Make sure we're not in a NavbarNav (close it if we are)
                Pop<NavbarNav>(writer);

                // Make sure we're in a collapse
                if (GetComponent<NavbarCollapse>() == null)
                {
                    GetHelper().NavbarCollapse().Component.Start(writer);
                }
            }

            base.OnStart(writer);
        }
    }
}
