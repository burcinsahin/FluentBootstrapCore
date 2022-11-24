using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FBootstrapCoreMvc.Components
{
    public class Select : HtmlComponent,
        ICanCreate<SelectOption>
    {
        private List<SelectOption> _options;

        public Select()
            : base("select", Css.FormSelect)
        {
        }

        protected override void Initialize()
        {
            _options.ForEach(o => AddChild(o));

            base.Initialize();
        }

        public Select SetOptions(IEnumerable<SelectListItem> selectList)
        {
            _options = new List<SelectOption>(selectList.Count());
            foreach (var item in selectList)
            {
                var option = new SelectOption()
                    .SetValue(item.Value)
                    .SetSelected(item.Selected)
                    .SetDisabled(item.Disabled)
                    .SetContent(item.Text);
                _options.Add(option);
            }
            return this;
        }

        protected internal void SetSelected(object? value)
        {
            if (value == null)
                return;
            foreach (var option in _options)
            {
                if (option.GetAttribute("value") == value?.ToString())
                    option.SetSelected();
            }
        }
    }
}