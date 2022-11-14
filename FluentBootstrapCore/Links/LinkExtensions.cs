using FluentBootstrapCore.Links;

namespace FluentBootstrapCore
{
    public static class LinkExtensions
    {
        // Link

        public static ComponentBuilder<TConfig, Link> Link<TConfig, TComponent>(this BootstrapHelper<TConfig, TComponent> helper, object text, string href = "#")
            where TConfig : BootstrapConfig
            where TComponent : Component, ICanCreate<Link>
        {
            return new ComponentBuilder<TConfig, Link>(helper.Config, new Link(helper)).SetHref(href).SetText(text);
        }

        // IHasLinkExtensions

        public static ComponentBuilder<TConfig, TTag> SetHref<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, string href)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasLinkExtensions
        {
            if (!string.IsNullOrWhiteSpace(href))
            {
                builder.Component.MergeAttribute("href", href);
            }
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetTarget<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, LinkTarget target)
            where TConfig : BootstrapConfig
            where TTag : Tag, IHasLinkExtensions
        {
            builder.Component.MergeAttribute("target", target.GetDescription());
            return builder;
        }

        public static ComponentBuilder<TConfig, TTag> SetColor<TConfig, TTag>(this ComponentBuilder<TConfig, TTag> builder, LinkColor color)
            where TConfig : BootstrapConfig
            where TTag : Link, IHasLinkExtensions
        {
            builder.Component.AddCss(color.GetDescription());
            return builder;
        }
    }
}
