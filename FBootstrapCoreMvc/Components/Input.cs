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

        public Input IsRequired()
        {
            MergeAttribute("required", true);
            return this;
        }

        public Input AutoFocus()
        {
            MergeAttribute("autofocus", true);
            return this;
        }

        public Input SetMaxLength(int value)
        {
            MergeAttribute("maxlength", value);
            return this;
        }

        public Input SetPlaceholder(string? text)
        {
            MergeAttribute("placeholder", text);
            return this;
        }

        public Input SetType(FormInputType inputType)
        {
            MergeAttribute("type", inputType.GetDescription());
            return this;
        }

        public Input SetName(string? name) {
            MergeAttribute("name", name);
            return this;
        }
    }
}