﻿using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;

namespace FBootstrapCoreMvc.Extensions
{
    public static class InputExtensions
    {
        public static BootstrapContent<TComponent> SetChecked<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool? value = null)
            where TComponent : SingleComponent, ICanBeChecked
        {
            if (!value.HasValue || value.Value)
                bootstrapContent.Component.MergeAttribute("checked");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetMaxLength<TComponent>(this BootstrapContent<TComponent> bootstrapContent, short maxLength = 100)
            where TComponent : SingleComponent, ICanHaveMaxLength
        {
            bootstrapContent.Component.MaxLength = maxLength;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> IsRequired<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeRequired
        {
            bootstrapContent.Component.Required = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetReadonly<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeReadonly
        {
            bootstrapContent.Component.Readonly = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetType<TComponent>(this BootstrapContent<TComponent> bootstrapContent, FormInputType type)
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


        //public static BootstrapContent<Select> Select(this IBootstrapHelper bootstrapHelper, string name, IEnumerable<SelectListItem> selectList)
        //{
        //    var select = new Select();
        //    select.MergeAttribute("name", name);
        //    select.SelectList = selectList;
        //    return new BootstrapContent<Select>(bootstrapHelper.HtmlHelper, select);
        //}

        public static BootstrapContent<InputGroup> InputGroup<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<InputGroup>
        {
            var inputGroup = new InputGroup();
            return new BootstrapContent<InputGroup>(builder.HtmlHelper, inputGroup);
        }

        public static BootstrapContent<HtmlElement> InputGroupText(this BootstrapBuilder<InputGroup> builder, object? content = null)
        {
            var inputGroupText = new HtmlElement("span", Css.InputGroupText)
            {
                Content = content
            };
            return new BootstrapContent<HtmlElement>(builder.HtmlHelper, inputGroupText);
        }

        public static BootstrapContent<Input> Input<TComponent>(this BootstrapBuilder<TComponent> builder)
            where TComponent : SingleComponent, ICanCreate<Input>
        {
            var input = new Input();
            return new BootstrapContent<Input>(builder.HtmlHelper, input);
        }
    }
}
