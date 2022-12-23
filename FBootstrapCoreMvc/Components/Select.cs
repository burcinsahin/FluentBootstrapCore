using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class Select : HtmlComponent,
        ICanCreate<SelectOption>
    {
        internal string? Name { get; set; }
        internal IEnumerable<SelectListItem>? SelectList { get; set; }
        public object? SelectedValue { get; set; }

        public Select()
            : base("select", Css.FormSelect)
        {
        }

        protected override void PreBuild()
        {
            if (SelectList != null)
            {
                var options = new List<SelectOption>(SelectList.Count());
                foreach (var item in SelectList)
                {
                    var option = new SelectOption()
                        .SetValue(item.Value)
                        .SetSelected(item.Selected)
                        .SetDisabled(item.Disabled)
                        .SetContent(item.Text);
                    options.Add(option);
                    if (SelectedValue != null)
                    {
                        if (option.GetAttribute("value") == SelectedValue.ToString())
                            option.SetSelected();
                    }
                    AddChild(option);
                }
            }

            base.PreBuild();
        }
    }
}