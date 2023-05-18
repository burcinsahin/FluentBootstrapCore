using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Navbar : BootstrapComponent,
        ICanCreate<NavbarBrand>,
        ICanCreate<NavbarCollapse>,
        ICanCreate<NavbarToggler>
    {
        public Breakpoint? Expand { get; set; }

        public Navbar()
            : base("nav", Css.Navbar)
        {
        }

        protected override void PreBuild()
        {
            if (Expand.HasValue)
                AddCss($"{Css.NavbarExpand}{Expand.Value.GetHyphenatedDescription()}");
            var container = new Container();
            container.ClearCss();
            container.AddCss(Css.ContainerFluid);
            AddChild(container, ChildLocation.FullWrap);

            base.PreBuild();
        }
    }
}