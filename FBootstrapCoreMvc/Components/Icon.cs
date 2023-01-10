using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;

namespace FBootstrapCoreMvc.Components
{
    public class Icon : SingleComponent
    {
        public Icon(IconType icon)
            : base("i")
        {
            AddCss($"bi bi-{icon.GetCssDescription()}");
        }
    }
}
