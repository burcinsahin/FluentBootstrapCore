using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Breadcrumb : BootstrapComponent,
        ICanCreate<BreadcrumbItem>
    {
        public Breadcrumb()
            : base("ol", Css.Breadcrumb)
        {
        }
    }
}