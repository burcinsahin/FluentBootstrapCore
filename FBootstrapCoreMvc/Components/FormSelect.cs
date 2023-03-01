﻿using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class FormSelect : SingleComponent,
        ICanHaveLabel,
        ICanHaveFloatingLabel,
        ICanHaveOptions
    {
        public string? Label { get; set; }
        public string? Name { get; set; }
        public IEnumerable<SelectListItem>? SelectList { get; set; }
        public object? SelectedValue { get; internal set; }
        public string? FloatingLabel { get; set; }

        public FormSelect()
            : base("div", Css.Mb3)
        {
        }

        protected override void PreBuild()
        {
            var select = new Select();
            select.SetId();

            if (Name != null)
                select.Name = Name;

            select.SelectList = SelectList;
            select.SelectedValue = SelectedValue;

            AddChild(select);

            if (FloatingLabel != null)
            {
                AddCss(Css.FormFloating);
                var label = new Label
                {
                    Content = FloatingLabel,
                    For = select.Id
                };
                AddChild(label);
            }
            else if (Label != null)
            {
                var label = new Label
                {
                    Content = Label,
                    For = select.Id
                };
                label.AddCss(Css.FormLabel);
                AddChild(label, ChildLocation.Header);
            }

            base.PreBuild();
        }
    }
}