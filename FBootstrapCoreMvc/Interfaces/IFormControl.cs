using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IFormControl :
        ICanBeReadonly,
        ICanHaveLabel,
        ICanHaveName,
        ICanHaveValue,
        ICanBeRequired,
        ICanBeDisabled,
        ICanBeInvalid
    {
        FormControlSize Size { get; set; }
    }
}