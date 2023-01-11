using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IButton :
        ICanHaveIcon,
        ICanHaveBadge,
        ICanPositionBadge,
        IButtonState,
        IButtonOutlineState
    {
        ButtonType ButtonType { get; set; }
    }
}