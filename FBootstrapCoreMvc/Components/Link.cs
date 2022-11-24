namespace FBootstrapCoreMvc.Components
{
    public class Link : HtmlComponent
    {
        public Link(object? content = null)
            : base("a")
        {
            AppendContent(content);
        }

        internal void SetRole(string role)
        {
            MergeAttribute("role", role);
        }

        //public Link SetHref(string href) => AddAttribute("href", href);
    }
}