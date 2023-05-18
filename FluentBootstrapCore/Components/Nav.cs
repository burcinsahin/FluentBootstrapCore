using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Nav : BootstrapComponent,
        INav, 
        ICanCreate<NavLink>
    {
        public Nav() : base("nav", Css.Nav)
        {
        }

        protected override void PreBuild()
        {
            if (HasParent<CardHeader>())
            {
                if (CssClasses.Contains(Css.NavTabs))
                    AddCss(Css.CardHeaderTabs);
                else if (CssClasses.Contains(Css.NavPills))
                    AddCss(Css.CardHeaderPills);
            }
            base.PreBuild();
        }
    }
}
