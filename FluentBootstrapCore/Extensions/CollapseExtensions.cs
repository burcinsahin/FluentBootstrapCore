using FluentBootstrapCore.Components;
using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Extensions
{
    public static class CollapseExtensions
    {
        /// <summary>
        /// Opens the collapse by default (<c>.show</c>).
        /// </summary>
        public static BootstrapContent<Collapse> Show(this BootstrapContent<Collapse> bootstrapContent, bool value = true)
        {
            bootstrapContent.Component.Show = value;
            return bootstrapContent;
        }

        /// <summary>
        /// Collapses horizontally (<c>.collapse-horizontal</c>). Set a width on the immediate child element.
        /// </summary>
        public static BootstrapContent<Collapse> Horizontal(this BootstrapContent<Collapse> bootstrapContent, bool value = true)
        {
            bootstrapContent.Component.Horizontal = value;
            return bootstrapContent;
        }

        /// <summary>
        /// Turns a button or link button into a collapse trigger.
        /// </summary>
        /// <param name="target">Id of the collapse element (with or without '#'), or a CSS selector such as ".multi-collapse" to toggle multiple elements.</param>
        /// <param name="expanded">Initial <c>aria-expanded</c> value; use true when the target is open by default.</param>
        /// <param name="controls">Value of <c>aria-controls</c>. Derived from <paramref name="target"/> when it is an id; pass the space-separated ids when using a selector.</param>
        public static BootstrapContent<TComponent> Collapse<TComponent>(
            this BootstrapContent<TComponent> bootstrapContent,
            string target,
            bool expanded = false,
            string? controls = null)
            where TComponent : BootstrapComponent, IButton
        {
            var component = bootstrapContent.Component;
            var selector = target.StartsWith('#') || target.StartsWith('.') ? target : $"#{target}";
            var isId = selector.StartsWith('#');

            component.MergeAttribute("data-bs-toggle", "collapse");

            if (isId && component is ILink link)
                link.Href = selector;
            else
                component.MergeAttribute("data-bs-target", selector);

            component.MergeAttribute("aria-expanded", expanded ? "true" : "false");

            controls ??= isId ? selector[1..] : null;
            if (controls != null)
                component.MergeAttribute("aria-controls", controls);

            return bootstrapContent;
        }
    }
}
