using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class Select : HtmlComponent,
        ICanCreate<SelectOption>
    {
        public Select()
            : base("select", Css.FormSelect)
        {
        }

        public Select SetOptions(IEnumerable<SelectListItem> selectList)
        {
            foreach (var item in selectList)
            {
                var option = new SelectOption()
                    .SetValue(item.Value)
                    .SetSelected(item.Selected)
                    .SetDisabled(item.Disabled)
                    .SetContent(item.Text);
                AddChild(option);
            }
            return this;
        }
    }
}