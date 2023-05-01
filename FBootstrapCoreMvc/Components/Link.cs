using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Link : BootstrapComponent, ILink
    {
        public string? Href { get; set; }
        public string? Role { get; set; }

        public Link()
            : base("a")
        {
            Href = "#";
        }

        protected override void PreBuild()
        {
            MergeAttribute("href", Href);

            if (Role != null)
                MergeAttribute("role", Role);

            base.PreBuild();
        }
    }
}