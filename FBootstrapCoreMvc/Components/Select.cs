using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class Select : Component<Select>,
        ICanCreate<SelectOption>
    {
        public Select(IHtmlHelper helper)
            : base(helper, "select", Css.FormSelect)
        {
        }

        public Select SetOptions(IEnumerable<SelectListItem> selectList)
        {
            foreach (var item in selectList)
            {
                var option = new SelectOption(_helper)
                    .SetValue(item.Value)
                    .SetSelected(item.Selected)
                    .SetDisabled(item.Disabled)
                    .SetContent(item.Text);
                _childComponents.Add(option);
            }
            AppendChildrenToHtml(true);
            return this;
        }
    }
}