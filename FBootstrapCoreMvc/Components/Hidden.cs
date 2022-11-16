using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FBootstrapCoreMvc.Components
{
    public class Hidden : Component<Hidden>,
        ICanHaveName,
        ICanHaveValue
    {
        public Hidden(IHtmlHelper helper)
            : base(helper, "input")
        {
            AddAttribute("type", FormInputType.Hidden.GetDescription());
        }
    }
}