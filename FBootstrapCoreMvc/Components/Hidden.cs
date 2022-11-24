using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Components
{
    public class Hidden : HtmlComponent,
        ICanHaveName,
        ICanHaveValue
    {
        public Hidden()
            : base("input")
        {
            MergeAttribute("type", FormInputType.Hidden.GetDescription());
        }
    }
}