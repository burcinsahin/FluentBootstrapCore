namespace FluentBootstrapCore.Components
{
    public class Nav : BootstrapComponent
    {
        public Nav() : base("ul", Css.Nav)
        {
        }

        protected override void PreBuild()
        {
            var parent = ComponentStackManager.ComponentStack?.Peek();
            if (parent is CardHeader)
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
