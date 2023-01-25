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
        public string? Action { get; set; }
        public string? Method { get; set; }
        public string? ConfirmMessage { get; set; }
        public Form()
            : base("form")
        {
        }

        protected override void PreBuild()
        {
            if (Action != null)
                MergeAttribute("action", Action);
            if (Method != null)
                MergeAttribute("method", Method);
            if (ConfirmMessage != null)
                MergeAttribute("onsubmit", $"return confirm('{ConfirmMessage}');");

            base.PreBuild();
        }
    }
}
