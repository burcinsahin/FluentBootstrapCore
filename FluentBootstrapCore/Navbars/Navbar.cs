using FluentBootstrapCore.Dropdowns;
using FluentBootstrapCore.Grids;
using System.IO;

namespace FluentBootstrapCore.Navbars
{
    public class Navbar : Tag,
        ICanCreate<NavbarHeader>,
        ICanCreate<NavbarCollapse>,
        ICanCreate<NavbarToggle>,
        ICanCreate<Brand>,
        ICanCreate<NavbarNav>,
        ICanCreate<Dropdown>,
        ICanCreate<NavbarForm>,
        ICanCreate<NavbarButton>,
        ICanCreate<NavbarText>,
        ICanCreate<NavbarLink>
    {
        private Container _container;

        public bool HasHeader { get; set; }
        public bool Fluid { get; set; }

        internal Navbar(BootstrapHelper helper)
            : base(helper, "nav", Css.Navbar/*, Css.NavbarDefault*/)
        {
            MergeAttribute("role", "navigation");
            GetBuilder(this).SetId("navbar");
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            _container = GetHelper().Container().SetFluid(Fluid).Component;
            _container.Start(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            if (!HasHeader)
            {
                GetHelper().NavbarHeader().Component.StartAndFinish(writer);
            }

            _container.Finish(writer);

            base.OnFinish(writer);
        }
    }
}
