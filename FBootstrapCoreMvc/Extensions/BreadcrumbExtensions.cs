using FBootstrapCoreMvc.Components;

namespace FBootstrapCoreMvc.Extensions
{
    public static class BreadcrumbExtensions
    {
        public static BootstrapContent<BreadcrumbItem> BreadcrumbItem(this BootstrapBuilder<Breadcrumb> builder, object? content = null)
        {
            var breadcrumbItem = new BreadcrumbItem
            {
                Content = content
            };
            return new BootstrapContent<BreadcrumbItem>(builder.HtmlHelper, breadcrumbItem);
        }
    }
}
