using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FluentBootstrapCore.Extensions
{
    public static class InputExtensions
    {
        //TODO: Move related methods to InterfaceExtensions
        public static BootstrapContent<TComponent> Checked<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool value = true)
            where TComponent : SingleComponent, ICanBeChecked
        {
            bootstrapContent.Component.Checked = value;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> MaxLength<TComponent>(this BootstrapContent<TComponent> bootstrapContent, short maxLength = 100)
            where TComponent : SingleComponent, ICanHaveMaxLength
        {
            bootstrapContent.Component.MaxLength = maxLength;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Required<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeRequired
        {
            bootstrapContent.Component.Required = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Readonly<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeReadonly
        {
            bootstrapContent.Component.Readonly = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Type<TComponent>(this BootstrapContent<TComponent> bootstrapContent, FormInputType type)
            where TComponent : FormInput
        {
            bootstrapContent.Component.Type = type;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AutoFocus<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : FormInput
        {
            bootstrapContent.Component.AutoFocus = true;
            return bootstrapContent;
        }

        public static BootstrapContent<Input> Type(this BootstrapContent<Input> bootstrapContent, FormInputType type)
        {
            bootstrapContent.Component.Type = type;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Placeholder<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string placeholder)
            where TComponent : SingleComponent, IPlaceholder
        {
            bootstrapContent.Component.Placeholder = placeholder;
            return bootstrapContent;
        }

        public static BootstrapContent<FormCheck> Switch(this BootstrapContent<FormCheck> bootstrapContent)
        {
            bootstrapContent.Component.Switch = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Inline<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeInline
        {
            bootstrapContent.Component.Inline = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Reverse<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeReverse
        {
            bootstrapContent.Component.Reverse = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Title<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? title)
            where TComponent : SingleComponent, ICanHaveTitle
        {
            bootstrapContent.Component.Title = title;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> FormText<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? text)
            where TComponent : SingleComponent, ICanHaveFormText
        {
            bootstrapContent.Component.FormText = text;
            return bootstrapContent;
        }

        public static BootstrapContent<FormCheck> Indeterminate(this BootstrapContent<FormCheck> bootstrapContent)
        {
            bootstrapContent.Component.Indeterminate = true;
            return bootstrapContent;
        }

        public static BootstrapContent<FormTextArea> Rows(this BootstrapContent<FormTextArea> bootstrapContent, short rows)
        {
            bootstrapContent.Component.Rows = rows;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Height<TComponent>(this BootstrapContent<TComponent> bootstrapContent, short height)
            where TComponent : SingleComponent, ICanHaveHeight
        {
            bootstrapContent.Component.Height = height;
            return bootstrapContent;
        }

        public static BootstrapContent<FormInput> PlainText(this BootstrapContent<FormInput> bootstrapContent)
        {
            bootstrapContent.Component.PlainText = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Multiple<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeMultiple
        {
            bootstrapContent.Component.Multiple = true;
            return bootstrapContent;
        }

        /// <summary>
        /// Turns a label into a horizontal form column label (<c>col-form-label</c>).
        /// </summary>
        /// <remarks>
        /// Replaces the default <c>form-label</c> class of the label with <c>col-form-label</c>, which aligns the
        /// label text vertically with the form control next to it inside a grid row. The width of the label is not
        /// set by this method; use <c>Columnize</c> (e.g. <c>Columnize(2, Breakpoint.Small)</c> for <c>col-sm-2</c>).
        /// </remarks>
        /// <param name="bootstrapContent">The label to convert.</param>
        /// <param name="size">
        /// Optional label size. <see cref="FormControlSize.Sm"/> adds <c>col-form-label-sm</c> and
        /// <see cref="FormControlSize.Lg"/> adds <c>col-form-label-lg</c>. <see cref="FormControlSize.Default"/> adds no size class.
        /// </param>
        /// <returns>The same label, for chaining.</returns>
        public static BootstrapContent<Label> ColumnLabel(this BootstrapContent<Label> bootstrapContent, FormControlSize size = FormControlSize.Default)
        {
            var label = bootstrapContent.Component;
            label.RemoveCss(Css.FormLabel);
            label.AddCss(Css.ColFormLabel);
            switch (size)
            {
                case FormControlSize.Sm:
                    label.AddCss(Css.ColFormLabelSm);
                    break;
                case FormControlSize.Lg:
                    label.AddCss(Css.ColFormLabelLg);
                    break;
            }
            return bootstrapContent;
        }

        /// <summary>
        /// Hides a label visually while keeping it available to screen readers (<c>visually-hidden</c>).
        /// </summary>
        /// <remarks>
        /// Replaces the default <c>form-label</c> class of the label with <c>visually-hidden</c>, so no
        /// label spacing styles remain on the hidden element.
        /// </remarks>
        /// <param name="bootstrapContent">The label to hide.</param>
        /// <returns>The same label, for chaining.</returns>
        public static BootstrapContent<Label> VisuallyHidden(this BootstrapContent<Label> bootstrapContent)
        {
            var label = bootstrapContent.Component;
            label.RemoveCss(Css.FormLabel);
            label.AddCss(Css.VisuallyHidden);
            return bootstrapContent;
        }

        public static BootstrapContent<InputGroup> InputGroup<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<InputGroup>
        {
            var inputGroup = new InputGroup();
            return new BootstrapContent<InputGroup>(builder.HtmlHelper, inputGroup);
        }

        public static BootstrapContent<InputGroupText> InputGroupText(this ComponentBuilder<InputGroup> builder, object? content = null)
        {
            var inputGroupText = new InputGroupText
            {
                Content = content
            };
            return new BootstrapContent<InputGroupText>(builder.HtmlHelper, inputGroupText);
        }

        /// <summary>
        /// Label addon (label.input-group-text) of an input group.
        /// </summary>
        public static BootstrapContent<Label> Label(this ComponentBuilder<InputGroup> builder, object? content = null, string? @for = null)
        {
            var label = new Label(content)
            {
                For = @for
            };
            return new BootstrapContent<Label>(builder.HtmlHelper, label);
        }

        public static BootstrapContent<Select> Select(this ComponentBuilder<InputGroup> builder, IEnumerable<SelectListItem>? options = null, string? name = null)
        {
            var select = new Select
            {
                Name = name,
                SelectList = options
            };
            return new BootstrapContent<Select>(builder.HtmlHelper, select);
        }

        public static BootstrapContent<SelectOption> Option<TComponent>(this ComponentBuilder<TComponent> builder, object? content = null, object? value = null)
            where TComponent : BootstrapComponent, ICanCreate<SelectOption>
        {
            var option = new SelectOption
            {
                Content = content,
                Value = value
            };
            return new BootstrapContent<SelectOption>(builder.HtmlHelper, option);
        }

        public static BootstrapContent<TextArea> TextArea(this ComponentBuilder<InputGroup> builder, string? name = null, object? value = null)
        {
            var textArea = new TextArea
            {
                Name = name,
                Value = value,
                Content = value
            };
            return new BootstrapContent<TextArea>(builder.HtmlHelper, textArea);
        }

        public static BootstrapContent<TextArea> Rows(this BootstrapContent<TextArea> bootstrapContent, short rows)
        {
            bootstrapContent.Component.Rows = rows;
            return bootstrapContent;
        }

        public static BootstrapContent<InputGroup> NoWrap(this BootstrapContent<InputGroup> bootstrapContent)
        {
            bootstrapContent.Component.NoWrap = true;
            return bootstrapContent;
        }

        public static BootstrapContent<CheckBox> CheckBox(this ComponentBuilder<InputGroupText> builder)
        {
            var checkBox = new CheckBox();
            return new BootstrapContent<CheckBox>(builder.HtmlHelper, checkBox);
        }

        public static BootstrapContent<RadioButton> RadioButton(this ComponentBuilder<InputGroupText> builder)
        {
            var radioButton = new RadioButton();
            return new BootstrapContent<RadioButton>(builder.HtmlHelper, radioButton);
        }

        public static BootstrapContent<Input> Input<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<Input>
        {
            var input = new Input();
            return new BootstrapContent<Input>(builder.HtmlHelper, input);
        }

        public static BootstrapContent<Button> DropdownToggle(this ComponentBuilder<InputGroup> builder, object? content = null)
        {
            var button = new Button
            {
                Content = content
            };
            button.AddCss(Css.DropdownToggle);
            button.MergeAttribute("data-bs-toggle", "dropdown");
            button.MergeAttribute("aria-expanded", false);
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }


    }
}
