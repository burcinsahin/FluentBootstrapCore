using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
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