using FluentBootstrapCore.Components;

namespace FluentBootstrapCore.Extensions
{
    public static class BreadcrumbExtensions
    {
        public static BootstrapContent<BreadcrumbItem> BreadcrumbItem(this ComponentBuilder<Breadcrumb> builder, object? content = null)
        {
            var breadcrumbItem = new BreadcrumbItem
            {
                Content = content
            };
            return new BootstrapContent<BreadcrumbItem>(builder.HtmlHelper, breadcrumbItem);
        }
    }
}
