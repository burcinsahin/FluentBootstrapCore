namespace FBootstrapCoreMvc.Components
{
    public class Label : HtmlComponent
    {
        public Label(object? content = null)
            : base("label")
        {
            Content = content;
        }
    }
}