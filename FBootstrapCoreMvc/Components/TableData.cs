namespace FBootstrapCoreMvc.Components
{
    public class TableData : HtmlComponent
    {
        public TableData(object? content = null)
            : base("td")
        {
            AppendContent(content);
        }
    }
}