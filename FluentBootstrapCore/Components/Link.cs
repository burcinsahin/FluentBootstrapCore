using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Link : BootstrapComponent, ILink
    {
        public string? Href { get; set; }
        public string? Role { get; set; }
        public LinkTarget? Target { get; set; }
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
            if (Target.HasValue)
                MergeAttribute("target", Target.GetDescription());

            base.PreBuild();
        }
    }
}