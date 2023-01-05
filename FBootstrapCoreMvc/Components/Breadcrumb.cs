using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Breadcrumb : HtmlComponent,
        ICanCreate<BreadcrumbItem>
    {
        public Breadcrumb()
            : base("ol", Css.Breadcrumb)
        {
        }
    }
}