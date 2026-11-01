using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;
using FluentBootstrapCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore.Components
{
    public class Select : BootstrapComponent,
        ICanCreate<SelectOption>,
        ICanBeMultiple,
        ICanBeDisabled,
        ICanHaveOptions,
        ICanHaveName,
        ICanBeRequired,
        ICanBeInvalid,
        ICanBeValid,
        ISizable<FormSelectSize>
    {
        public string? Name { get; set; }
        public IEnumerable<SelectListItem>? SelectList { get; set; }
        public object? SelectedValue { get; set; }
        public bool Multiple { get; set; }
        public bool Disabled { get; set; }
        public bool Required { get; set; }
        public bool Invalid { get; set; }
        public bool Valid { get; set; }
        public FormSelectSize? Size { get; set; }

        public Select()
            : base("select", Css.FormSelect)
        {
            Size = FormSelectSize.Default;
        }

        protected override void PreBuild()
        {
            if (Name != null)
                MergeAttribute("name", Name);
            if (Multiple)
                MergeAttribute("multiple");
            if (Disabled)
                MergeAttribute("disabled");
            if (Required)
                MergeAttribute("required", true);
            if (Invalid)
                AddCss(Css.IsInvalid);
            if (Valid)
                AddCss(Css.IsValid);

            if (Size.HasValue && Size != FormSelectSize.Default)
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