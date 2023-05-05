using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    public interface ILink
    {
        string? Href { get; set; }
        LinkTarget? Target { get; set; }
    }
}