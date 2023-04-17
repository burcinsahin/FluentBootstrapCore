using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class LinkButton : ButtonComponent, ILink
    {
        public string? Href { get; set; }

        public LinkButton(object? content = null)
            : base("a")
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "button");

            base.PreBuild();
        }
    }
}