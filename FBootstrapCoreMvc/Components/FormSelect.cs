using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class FormSelect : HtmlComponent
    {
        private Select _select;
        private Label _label;

        public FormSelect(string? label)
            : base("div", Css.FormFloating)
        {
            _select = new Select().SetId();
            _label = new Label();
            _label.SetContent(label);
            _label.MergeAttribute("for", _select.Id);
            AddChild(_select);
            AddChild(_label);
        }

        public FormSelect SetName(string? name)
        {
            _select.MergeAttribute("name", name);
            return this;
        }

        public FormSelect SetOptions(IEnumerable<SelectListItem> selectList)
        {
            _select.SetOptions(selectList);
            return this;
        }

        public FormSelect SetSelected(object? value)
        {
            _select.SetSelected(value);
            return this;
        }

    }
}