namespace FluentBootstrapCore.Components
{
    public class HtmlElement(string tagName, params string[] cssClasses) : BootstrapComponent(tagName, cssClasses)
    {
    }
}
