namespace FluentBootstrapCore.Components
{
    public class Label : BootstrapComponent
    {
        public string? For { get; set; }

        public Label(object? content = null)
            : base("label")
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            if (For != null)
                MergeAttribute("for", For);

            if (HasParent<InputGroup>())
            {
                // Inside an input group the label is an addon, not a regular form label
                RemoveCss(Css.FormLabel);
                AddCss(Css.InputGroupText);
            }

            base.PreBuild();
        }
    }
}