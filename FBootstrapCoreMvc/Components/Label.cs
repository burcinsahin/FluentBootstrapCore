namespace FBootstrapCoreMvc.Components
{
    public class Label : SingleComponent
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
            {
                MergeAttribute("for", For);
            }

            base.PreBuild();
        }
    }
}