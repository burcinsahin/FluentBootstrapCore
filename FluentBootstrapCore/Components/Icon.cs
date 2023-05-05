using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;

namespace FluentBootstrapCore.Components
{
    public class Icon : BootstrapComponent
    {
        public Icon(IconType icon)
            : base("i")
        {
            AddCss($"bi bi-{icon.GetCssDescription()}");
        }
    }
}
