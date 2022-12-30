using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IHaveButtonExtensions :
        ICanHaveIcon
    {
        ButtonState ButtonState { get; set; }
        ButtonType ButtonType { get; set; }
    }
}