using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class InputExtensions
    {
        public static BootstrapContent<CheckBox> CheckBox(this IBootstrapHelper bootstrapHelper)
        {
            return new BootstrapContent<CheckBox>(bootstrapHelper.HtmlHelper, new CheckBox());
        }

        public static BootstrapContent<TComponent> SetChecked<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool? value = null)
            where TComponent : HtmlComponent, ICanBeChecked
        {
            if (!value.HasValue || value.Value)
                bootstrapContent.Component.MergeAttribute("checked");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetMaxLength<TComponent>(this BootstrapContent<TComponent> bootstrapContent, short value = 100)
            where TComponent : FormInput
        {
            bootstrapContent.Component.SetMaxLength(value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> IsRequired<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : FormInput
        {
            bootstrapContent.Component.IsRequired();
            return bootstrapContent;
        }
    }
}
