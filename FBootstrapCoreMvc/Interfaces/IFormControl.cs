using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Interfaces
{
    public interface IFormControl :
        ICanBeReadonly,
        ICanHaveLabel,
        ICanHaveName,
        ICanHaveValue,
        ICanBeRequired,
        ICanBeDisabled
    {
        FormControlSize Size { get; set; }
    }
}