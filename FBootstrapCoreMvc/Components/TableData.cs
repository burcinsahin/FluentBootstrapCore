namespace FluentBootstrapCore.Components
{
    public class TableData : BootstrapComponent
    {
        public TableData(object? content = null)
            : base("td")
        {
            AppendContent(content);
        }
    }
}