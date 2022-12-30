using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface ICanHaveIcon
    {
        IconType? IconType { get; set; }
    }
}