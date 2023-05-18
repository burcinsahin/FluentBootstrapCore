using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class NavList : List,
        ICanCreate<NavItem>, 
        INav,
        ICanCreate<NavDropdown>
    {
        public NavList() : base(ListType.Unstyled)
        {
        }

        protected override void PreBuild()
        {
            AddCss(Css.Nav);
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
