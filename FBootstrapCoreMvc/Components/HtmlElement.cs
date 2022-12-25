namespace FBootstrapCoreMvc.Components
{
    public class HtmlElement : HtmlComponent
    {
        public HtmlElement(string tagName, params string[] cssClasses) 
            : base(tagName, cssClasses)
        {
        }

        public string Placeholder { get; internal set; }
    }
}
