using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Extensions
{
    public static class UtilExtensions
    {
        public static BootstrapContent<TComponent> Border<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Border border = Enums.Border.All)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(border.GetCssDescription());
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Display<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Display display, Breakpoint br = Breakpoint.Default)
            where TComponent : SingleComponent
        {
            var displayCss = string.Format(display.GetCssDescription(), br.GetHyphenatedDescription());
            bootstrapContent.Component.AddCss(displayCss);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Overflow<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Overflow overflow = Enums.Overflow.Auto)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(overflow.GetCssDescription());
            return bootstrapContent;
        }

    }
}
