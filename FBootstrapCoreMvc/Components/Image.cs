using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Image : SingleComponent, IColumnizable
    {
        public Image()
            : base("img")
        {
        }
    }
}
