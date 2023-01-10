using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Form : SingleComponent,
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

        protected internal Form SetAction(string? action)
        {
            MergeAttribute("action", action);
            return this;
        }

        protected internal Form SetMethod(string method)
        {
            MergeAttribute("method", method);
            return this;
        }

        protected internal Form SetConfirm(string message)
        {
            MergeAttribute("onsubmit", $"return confirm('{message}');");
            return this;
        }
    }
}
