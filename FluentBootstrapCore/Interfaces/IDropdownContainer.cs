using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Interfaces
{
    /// <summary>
    /// A wrapper (<see cref="Components.Dropdown"/>, <see cref="Components.ButtonGroup"/>) that hosts a dropdown toggle and menu.
    /// </summary>
    public interface IDropdownContainer
    {
        DropdownDirection Direction { get; set; }
        bool Centered { get; set; }
    }
}
