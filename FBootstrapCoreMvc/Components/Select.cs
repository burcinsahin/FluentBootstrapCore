using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class Select : SingleComponent,
        ICanCreate<SelectOption>,
        ICanBeMultiple,
        ICanBeDisabled,
        ISizable<FormSelectSize>
    {
        public string? Name { get; set; }
        internal IEnumerable<SelectListItem>? SelectList { get; set; }
        public object? SelectedValue { get; set; }
        public bool Multiple { get; set; }
        public bool Disabled { get; set; }
        public FormSelectSize Size { get; set; }

        public Select()
            : base("select", Css.FormSelect)
        {
        }

        protected override void PreBuild()
        {
            if (Name != null)
                MergeAttribute("name", Name);
            if (Multiple)
                MergeAttribute("multiple");
            if (Disabled)
                MergeAttribute("disabled");
            
            if (Size != FormSelectSize.Default)
                AddCss(Size.GetCssDescription());

            if (SelectList != null)
            {
                var options = new List<SelectOption>(SelectList.Count());
                foreach (var item in SelectList)
                {
                    var option = new SelectOption
                    {
                        Value = item.Value,
                        Selected = item.Selected,
                        Disabled = item.Disabled,
                        Content = item.Text
                    };

                    options.Add(option);
                    if (SelectedValue != null)
                    {
                        if (option.GetAttribute("value") == SelectedValue.ToString())
                            option.Selected = true;
                    }
                    AddChild(option);
                }
            }

            base.PreBuild();
        }
    }
}