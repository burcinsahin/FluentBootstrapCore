using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    /// <summary>
    /// Addon of an <see cref="InputGroup"/>. Renders a &lt;span class="input-group-text"&gt; element.
    /// CheckBox and RadioButton created inside it get the form-check-input class automatically.
    /// </summary>
    public class InputGroupText : BootstrapComponent,
        ICanCreate<CheckBox>,
        ICanCreate<RadioButton>
    {
        public InputGroupText()
            : base("span", Css.InputGroupText)
        {
        }
    }
}
