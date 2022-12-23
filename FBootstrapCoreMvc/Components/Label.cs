namespace FBootstrapCoreMvc.Components
{
    public class Label : HtmlComponent
    {
        public string? For { get; set; }

        public Label(object? content = null)
            : base("label")
        {
            Content = content;
        }

        protected override void Initialize()
        {
            if (For != null)
            {
                MergeAttribute("for", For);
            }

            base.Initialize();
        }
    }
}