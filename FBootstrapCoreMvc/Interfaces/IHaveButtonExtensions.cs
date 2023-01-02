using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IHaveButtonExtensions :
        ICanHaveIcon,
        ICanHaveBadge,
        ICanPositionBadge
    {
        ButtonState ButtonState { get; set; }
        ButtonType ButtonType { get; set; }
    }
}