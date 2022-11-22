using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Input : HtmlComponent,
        ICanHaveValue
    {
        public Input()
            : base("input")
        {
        }

        public Input IsRequired() => AddAttribute("required", true);

        public Input AutoFocus() => AddAttribute("autofocus", true);

        public Input SetMaxLength(int value) => AddAttribute("maxlength", value);

        public Input SetPlaceholder(string? text) => AddAttribute("placeholder", text);

        public Input SetType(FormInputType inputType) => AddAttribute("type", inputType.GetDescription());

        public Input SetName(string? name) => AddAttribute("name", name);
    }
}