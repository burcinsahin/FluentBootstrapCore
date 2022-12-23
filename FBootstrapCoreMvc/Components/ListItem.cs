namespace FBootstrapCoreMvc.Components
{
    public class ListItem : HtmlComponent
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