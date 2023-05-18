using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class LinkExtensions
    {
        public static BootstrapContent<TComponent> Tooltip<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string tooltip,
            PopperDirection? direction = null,
            string? customClass = null)
            where TComponent : Link
        {
            bootstrapContent.Component.MergeAttribute("data-bs-toggle", "tooltip");
            bootstrapContent.Component.MergeAttribute("title", tooltip);
            if (direction.HasValue)
                bootstrapContent.Component.MergeAttribute("data-bs-placement", direction.GetDescription());
            if (customClass != null)
                bootstrapContent.Component.MergeAttribute("data-bs-custom-class", customClass);

            return bootstrapContent;
        }
    }
}
