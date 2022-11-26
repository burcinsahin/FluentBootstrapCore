﻿using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using System;
using System.Threading.Tasks;

namespace FBootstrapCoreMvc.Extensions
{
    public static class InputExtensions
    {
        public static BootstrapContent<CheckBox> CheckBox(this IBootstrapHelper bootstrapHelper)
        {
            return new BootstrapContent<CheckBox>(bootstrapHelper.HtmlHelper, new CheckBox());
        }

        public static BootstrapContent<TComponent> SetChecked<TComponent>(this BootstrapContent<TComponent> bootstrapContent, bool? value = null)
            where TComponent : HtmlComponent, ICanBeChecked
        {
            if (!value.HasValue || value.Value)
                bootstrapContent.Component.MergeAttribute("checked");
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetMaxLength<TComponent>(this BootstrapContent<TComponent> bootstrapContent, short value = 100)
            where TComponent : FormInput
        {
            bootstrapContent.Component.SetMaxLength(value);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> IsRequired<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : FormInput
        {
            bootstrapContent.Component.IsRequired();
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetReadonly<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : HtmlComponent, ICanBeReadonly
        {
            bootstrapContent.Component.Readonly = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetFloatingLabel<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? label)
            where TComponent : FormInput
        {
            bootstrapContent.Component.SetFloatingLabel(label);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetType<TComponent>(this BootstrapContent<TComponent> bootstrapContent, FormInputType type)
            where TComponent : FormInput
        {
            bootstrapContent.Component.SetType(type);
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> AutoFocus<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : FormInput
        {
            bootstrapContent.Component.AutoFocus();
            return bootstrapContent;
        }
    }
}
