using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ButtonExtensions
    {
        public static TComponent SetSize<TComponent>(this TComponent component, ButtonSize size = ButtonSize.Default)
            where TComponent : Component<TComponent>, IHaveButtonExtensions
        {
            return component.AddCss(size.GetCssDescription());
        }

        //public static TComponent SetName<TComponent>(this TComponent component, string name)
        //    where TComponent : Component<TComponent>, IHaveButtonExtensions
        //{
        //    return component.AddAttribute("name", name);
        //}

    }
}
