namespace FBootstrapCoreMvc.Components
{
    public class NavbarToggler : HtmlComponent
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
    }
}