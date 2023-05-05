using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
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