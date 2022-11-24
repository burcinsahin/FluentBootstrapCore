using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Form : HtmlComponent,
        ICanCreate<FormInput>,
        ICanCreate<FormSelect>,
        ICanCreate<FormCheck>,
        ICanCreate<FormRadio>,
        ICanCreate<Button>,
        ICanCreate<Label>
    {
        public Form()
            : base("form")
        {
        }

        public Form SetAction(string? action)
        {
            MergeAttribute("action", action);
            return this;
        }

        public Form SetMethod(string method)
        {
            MergeAttribute("method", method);
            return this;
        }

        public Form SetConfirm(string message)
        {
            MergeAttribute("onsubmit", $"return confirm('{message}');");
            return this;
        }
    }
}
