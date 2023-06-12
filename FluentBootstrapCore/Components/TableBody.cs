namespace FluentBootstrapCore.Components
{
    public class TableBody : BootstrapComponent
    {
        public bool Divider { get; set; }
        public TableBody() : base("tbody")
        {
        }

        protected override void PreBuild()
        {
            if (Divider)
                AddCss(Css.TableGroupDivider);

            base.PreBuild();
        }
    }
}