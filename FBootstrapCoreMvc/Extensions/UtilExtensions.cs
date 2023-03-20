using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Extensions
{
    public static class UtilExtensions
    {
        public static BootstrapContent<TComponent> Border<TComponent>(this BootstrapContent<TComponent> bootstrapContent, Border border)
            where TComponent : SingleComponent
        {
            bootstrapContent.Component.AddCss(border.GetCssDescription());
            return bootstrapContent;
        }

    }
}
