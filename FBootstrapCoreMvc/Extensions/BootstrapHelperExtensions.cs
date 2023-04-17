namespace FBootstrapCoreMvc.Extensions
{
    public static class BootstrapHelperExtensions
    {
        public static BootstrapContent<TComponent> VisuallyHidden<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool focusable = false)
            where TComponent : BootstrapComponent
        {
            if (focusable)
                bootstrapContent.Component.AddCss(Css.VisuallyHiddenFocusable);
            else
                bootstrapContent.Component.AddCss(Css.VisuallyHidden);

            return bootstrapContent;
        }

    }
}
