using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc.Components
{
    public class SelectOption : Component<SelectOption>,
        ICanHaveValue, ICanBeDisabled, ICanBeSelected
    {
        public SelectOption(IHtmlHelper helper)
            : base(helper, "option")
        {
        }

        public SelectOption SetSelected(bool selected = false)
        {
            if (!selected) return this;
            return AddAttribute("selected", "");
        }
    }
}