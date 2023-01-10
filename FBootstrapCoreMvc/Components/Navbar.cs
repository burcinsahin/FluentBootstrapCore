using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Navbar : SingleComponent,
        ICanCreate<NavbarBrand>,
        ICanCreate<NavbarCollapse>,
        ICanCreate<NavbarToggler>
    {
        public Navbar()
            : base("nav", Css.Navbar, Css.NavbarExpandLg)
        {
        }

        protected override void PreBuild()
        {
            var container = new Container();
            container.ClearCss();
            container.AddCss(Css.ContainerFluid);
            AddWrappingChild(container, WrapperType.All);

            base.PreBuild();
        }
    }
}