using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
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