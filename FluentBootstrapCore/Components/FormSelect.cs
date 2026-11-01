using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FluentBootstrapCore.Components
{
    public class FormSelect : BootstrapComponent,
        ICanHaveLabel,
        ICanHaveFloatingLabel,
        ICanHaveOptions,
        ICanBeRequired,
        ICanBeInvalid,
        ICanBeValid,
        ICanHaveFeedback
    {
        public string? Label { get; set; }
        public string? Name { get; set; }
        public IEnumerable<SelectListItem>? SelectList { get; set; }
        public object? SelectedValue { get; internal set; }
        public string? FloatingLabel { get; set; }
        public bool Required { get; set; }
        public bool Invalid { get; set; }
        public bool Valid { get; set; }
        public string? ValidFeedback { get; set; }
        public string? InvalidFeedback { get; set; }
        public bool FeedbackTooltip { get; set; }

        public FormSelect()
            : base("div", Css.Mb3)
        {
        }

        protected override void PreBuild()
        {
            var select = new Select();

            // Like the other form controls, the id belongs to the input element, not to the wrapper
            if (Id != null)
            {
                select.Id = Id;
                Id = null;
            }
            else
            {
                select.GenerateId();
            }

            if (Name != null)
                select.Name = Name;

            select.SelectList = SelectList;
            select.SelectedValue = SelectedValue;
            select.Required = Required;
            select.Invalid = Invalid;
            select.Valid = Valid;

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

            ValidationFeedback.Apply(this, this, select, Invalid, Valid);

            base.PreBuild();
        }
    }
}
