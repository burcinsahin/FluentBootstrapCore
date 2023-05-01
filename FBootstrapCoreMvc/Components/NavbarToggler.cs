namespace FluentBootstrapCore.Components
{
    public class NavbarToggler : BootstrapComponent
    {
        public NavbarToggler(string? collapseId)
            : base("button", Css.NavbarToggler)
        {
            MergeAttribute("type", "button");
            MergeAttribute("data-bs-toggle", "collapse");
            MergeAttribute("data-bs-target", $"#{collapseId}");
            MergeAttribute("aria-controls", collapseId);
            MergeAttribute("aria-expanded", false);
            MergeAttribute("aria-label", "Toggle");
        }

        protected override void PreBuild()
        {
            var span = new HtmlElement("span", Css.NavbarTogglerIcon);
            AddChild(span);
            base.PreBuild();
        }
    }
}