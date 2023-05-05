using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Interfaces;
using System;

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

        public static BootstrapContent<TComponent> Placeholder<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string placeholder)
            where TComponent : SingleComponent, IPlaceholder
        {
            bootstrapContent.Component.Placeholder = placeholder;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Size<TComponent>(this BootstrapContent<TComponent> bootstrapContent, FormControlSize size)
            where TComponent : SingleComponent, IFormControl
        {
            bootstrapContent.Component.Size = size;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Sized<TComponent, TEnum>(this BootstrapContent<TComponent> bootstrapContent, TEnum size)
            where TComponent : SingleComponent, ISizable<TEnum>
            where TEnum : struct, Enum
        {
            bootstrapContent.Component.Size = size;
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

        public static BootstrapContent<InputGroup> InputGroup<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<InputGroup>
        {
            var inputGroup = new InputGroup();
            return new BootstrapContent<InputGroup>(builder.HtmlHelper, inputGroup);
        }

        public static BootstrapContent<HtmlElement> InputGroupText(this ComponentBuilder<InputGroup> builder, object? content = null)
        {
            var inputGroupText = new HtmlElement("span", Css.InputGroupText)
            {
                Content = content
            };
            return new BootstrapContent<HtmlElement>(builder.HtmlHelper, inputGroupText);
        }

        public static BootstrapContent<Input> Input<TComponent>(this ComponentBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<Input>
        {
            var input = new Input();
            return new BootstrapContent<Input>(builder.HtmlHelper, input);
        }


    }
}
