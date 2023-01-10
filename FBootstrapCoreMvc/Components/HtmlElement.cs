namespace FBootstrapCoreMvc.Components
{
    public class HtmlElement : SingleComponent
    {
        public HtmlElement(string tagName, params string[] cssClasses) 
            : base(tagName, cssClasses)
        {
        }
    }
}
