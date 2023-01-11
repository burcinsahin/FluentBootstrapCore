namespace FBootstrapCoreMvc.Components
{
    public class TableData : SingleComponent
    {
        public TableData(object? content = null)
            : base("td")
        {
            AppendContent(content);
        }
    }
}