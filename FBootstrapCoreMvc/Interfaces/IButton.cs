using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IButton :
        ICanHaveIcon,
        ICanHaveBadge,
        ICanPositionBadge
    {
        ButtonState ButtonState { get; set; }
        ButtonType ButtonType { get; set; }
        ButtonOutlineState? OutlineState { get; set; }
    }
}