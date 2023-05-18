using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    public interface IPopover : ICanBeDisabled, 
        ISizable<ButtonSize>
    {
        string? CustomClass { get; set; }
        string? Container { get; set; }
        PopperDirection? Direction { get; set; }
        string? PopoverContent { get; set; }
        string? PopoverTitle { get; set; }
        bool Dismissable { get; set; }
        ButtonState? State { get; set; }
    }
}