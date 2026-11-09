namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Collapsible element (<c>.collapse</c>), toggled by a button or link that targets its id.
    /// </summary>
    public class Collapse : BootstrapComponent
    {
        /// <summary>
        /// Open by default (<c>.show</c>).
        /// </summary>
        public bool Show { get; set; }

        /// <summary>
        /// Transitions the width instead of the height (<c>.collapse-horizontal</c>).
        /// </summary>
        public bool Horizontal { get; set; }

        public Collapse()
            : base("div", Css.Collapse)
        {
        }

        protected override void PreBuild()
        {
            if (Show)
                AddCss(Css.Show);

            if (Horizontal)
                AddCss(Css.CollapseHorizontal);

            base.PreBuild();
        }
    }
}
