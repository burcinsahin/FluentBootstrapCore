using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public abstract class BaseInput : HtmlComponent,
        ICanHaveValue, 
        ICanHaveName, 
        ICanBeDisabled
    {
        public BaseInput(FormInputType inputType, params string[] cssClasses)
            : base("input", cssClasses)
        {
            MergeAttribute("type", inputType.GetDescription());
        }
    }
}
