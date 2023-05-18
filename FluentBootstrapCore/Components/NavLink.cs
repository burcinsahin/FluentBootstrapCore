using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavLink : Link,
        ICanBeActive,
        ICanBeDisabled
    {
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        public NavLink() : base()
        {
        }

        protected override void PreBuild()
        {
            AddCss(Css.NavLink);
            if (Active)
                AddCss(Css.Active);
            if (Disabled)
                AddCss(Css.Disabled);

            base.PreBuild();
        }
    }
}
