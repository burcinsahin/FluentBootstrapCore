using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    public interface ICanHaveIcon
    {
        IconType? IconType { get; set; }
    }
}