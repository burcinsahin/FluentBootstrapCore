using FBootstrapCoreMvc.Components;

namespace FBootstrapCoreMvc.Extensions
{
    public static class InputExtensions
    {
        public static BootstrapContent<CheckBox> CheckBox(this IBootstrapHelper bootstrapHelper)
        {
            return new BootstrapContent<CheckBox>(bootstrapHelper.HtmlHelper, new CheckBox());
        }

        public static BootstrapContent<TComponent> SetChecked<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool? value = null)
            where TComponent : HtmlComponent
        {
            if (!value.HasValue || value.Value)
                bootstrapContent.Component.MergeAttribute("checked");
            return bootstrapContent;
        }
    }
}
