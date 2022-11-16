using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Form<TModel> : MvcComponent<Form<TModel>, TModel>,
        ICanCreate<FormInput>,
        ICanCreate<FormSelect>,
        ICanCreate<FormCheck>,
        ICanCreate<FormRadio>,
        ICanCreate<Button>,
        ICanCreate<Label>
    {
        public Form(IHtmlHelper<TModel> helper)
            : base(helper, "form")
        {
        }

        public Form<TModel> SetAction(string? action)
        {
            MergeAttribute("action", action);
            return this;
        }

        public Form<TModel> SetMethod(string method)
        {
            MergeAttribute("method", method);
            return this;
        }

        public Form<TModel> SetConfirm(string message)
        {
            MergeAttribute("onsubmit", $"return confirm('{message}');");
            return this;
        }
    }
}
