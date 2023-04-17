using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IButton :
        ICanHaveIcon,
        ICanHaveBadge,
        IButtonState,
        IButtonOutlineState
    {
        ButtonType ButtonType { get; set; }
    }
}