using System.ComponentModel;

namespace FluentBootstrapCore.Enums
{
    /// <summary>
    /// Value of the <c>data-bs-reference</c> attribute of a dropdown toggle.
    /// </summary>
    public enum DropdownReference
    {
        [Description("toggle")]
        Toggle,
        [Description("parent")]
        Parent
    }
}
