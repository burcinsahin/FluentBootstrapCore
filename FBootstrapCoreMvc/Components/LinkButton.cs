namespace FBootstrapCoreMvc.Components
{
    public class LinkButton : BaseButton
        
    {
        public LinkButton(object? content = null)
            : base("a")
        {
            Content = content;
        }

        protected override void PreBuild()
        {
            MergeAttribute("role", "button");

            base.PreBuild();
        }
    }
}