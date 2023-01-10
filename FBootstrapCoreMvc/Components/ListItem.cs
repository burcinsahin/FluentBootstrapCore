namespace FBootstrapCoreMvc.Components
{
    public class ListItem : SingleComponent
    {
        public bool Inline { get; set; }

        public ListItem()
            : base("li")
        {
        }

        protected override void PreBuild()
        {
            if (Inline)
                AddCss(Css.ListInlineItem);
            base.PreBuild();
        }
    }
}