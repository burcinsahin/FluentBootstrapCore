namespace FBootstrapCoreMvc.Components
{
    public class Heading : HtmlComponent
    {
        public Heading(byte size)
            : base($"h{size}")
        {
        }
    }
}
