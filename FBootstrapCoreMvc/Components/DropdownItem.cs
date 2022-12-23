using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class DropdownItem : HtmlComponent,
        ILink
    {
        public string? Href { get; set; }
        public DropdownItem()
            : base("li")
        {
        }

        protected override void PreBuild()
        {
            var link = new Link
            {
                Content = Content,
                Href = Href
            };
            link.AddCss(Css.DropdownItem);
            AddChild(link);
            Content = null;
            base.PreBuild();
        }
    }
}