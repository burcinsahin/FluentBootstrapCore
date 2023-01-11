using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Breadcrumb : SingleComponent,
        ICanCreate<BreadcrumbItem>
    {
        public Breadcrumb()
            : base("ol", Css.Breadcrumb)
        {
        }
    }
}