using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Extensions;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FBootstrapCoreMvc.Components
{
    public class FormSelect : Component<FormSelect>
    {
        private Select _select;
        private Label _label;

        public FormSelect(IHtmlHelper helper, string? label)
            : base(helper, "div", Css.FormFloating)
        {
            _select = new Select(helper).SetId();
            _label = new Label(helper).SetContent(label).AddAttribute("for", _select.Id);
            _childComponents.Add(_select);
            _childComponents.Add(_label);
            AppendChildrenToHtml();
        }

        public FormSelect SetName(string? name)
        {
            _select.AddAttribute("name", name);
            AppendChildrenToHtml(true);
            return this;
        }

        public FormSelect SetOptions(IEnumerable<SelectListItem> selectList)
        {
            _select.SetOptions(selectList);
            AppendChildrenToHtml(true);
            return this;
        }
    }
}