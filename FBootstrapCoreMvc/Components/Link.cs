using FBootstrapCoreMvc.Interfaces;
using System.Data;

namespace FBootstrapCoreMvc.Components
{
    public class Link : SingleComponent, ILink
    {
        public string? Href { get; set; }
        public string? Role { get; set; }

        public Link(object? content = null)
            : base("a")
        {
            Content = content;
            Role = "button";
            Href= "#";
        }

        protected override void PreBuild()
        {
            MergeAttribute("href", Href);
            MergeAttribute("role", Role);

            base.PreBuild();
        }
    }
}