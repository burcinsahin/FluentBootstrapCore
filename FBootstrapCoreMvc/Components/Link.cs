namespace FBootstrapCoreMvc.Components
{
    public class Link : HtmlComponent
    {
        public Link(object? content = null)
            : base("a")
        {
            Content = content;
        }

        protected internal void SetRole(string role)
        {
            MergeAttribute("role", role);
        }

        protected internal Link SetHref(string href)
        {
            MergeAttribute("href", href);
            return this;
        }
    }
}