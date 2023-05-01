using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Extensions
{
    public static class PaginationExtensions
    {
        #region Pagination
        public static BootstrapContent<Pagination> AddPageItem(this BootstrapContent<Pagination> bootstrapContent, string? href, object? content, bool active = false, bool disabled = false)
        {
            var pageItem = new PageItem();
            pageItem.Link.Href = href;
            pageItem.Link.Content = content;
            pageItem.Active = active;
            pageItem.Disabled = disabled;
            bootstrapContent.Component.AddChild(pageItem);
            return bootstrapContent;
        }

        //public static BootstrapContent<Pagination> JustifyContent(this BootstrapContent<Pagination> bootstrapContent, JustifyContent justifyContent)
        //{
        //    bootstrapContent.Component.AddCss(justifyContent.GetCssDescription());
        //    return bootstrapContent;
        //}

        public static BootstrapContent<Pagination> Size(this BootstrapContent<Pagination> bootstrapContent, ComponentSize size)
        {
            if (size == ComponentSize.Normal)
                return bootstrapContent;
            bootstrapContent.Component.AddCss($"{Css.Pagination}-{size.GetSuffix()}");
            return bootstrapContent;
        }
        #endregion

        #region PageItem
        public static BootstrapContent<PageItem> PageItem(this BootstrapBuilder<Pagination> builder, object? content)
        {
            var pageItem = new PageItem();
            pageItem.Link.Href = "#";
            pageItem.Link.Content = content;
            return new BootstrapContent<PageItem>(builder.HtmlHelper, pageItem);
        }

        public static BootstrapContent<PageItem> Link(this BootstrapContent<PageItem> bootstrapContent, string? href, object? content)
        {
            bootstrapContent.Component.Link.Href = href;
            bootstrapContent.Component.Link.Content = content;
            return bootstrapContent;
        }

        //public static BootstrapContent<PageItem> Active(this BootstrapContent<PageItem> bootstrapContent)
        //{
        //    bootstrapContent.Component.Active = true;
        //    return bootstrapContent;
        //}

        //public static BootstrapContent<PageItem> Disabled(this BootstrapContent<PageItem> bootstrapContent)
        //{
        //    bootstrapContent.Component.Disabled = true;
        //    return bootstrapContent;
        //}
        #endregion
    }
}
