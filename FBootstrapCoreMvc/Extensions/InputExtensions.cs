using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
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

        public static BootstrapContent<TComponent> SetMaxLength<TComponent>(this BootstrapContent<TComponent> bootstrapContent, short maxLength = 100)
            where TComponent : HtmlComponent, ICanHaveMaxLength
        {
            bootstrapContent.Component.MaxLength = maxLength;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> IsRequired<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : FormInput
        {
            bootstrapContent.Component.Required = true;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> SetReadonly<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : HtmlComponent, ICanBeReadonly
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

        public static BootstrapContent<Select> Select(this IBootstrapHelper bootstrapHelper, string name, IEnumerable<SelectListItem> selectList)
        {
            var select = new Select();
            select.MergeAttribute("name", name);
            select.SelectList = selectList;
            return new BootstrapContent<Select>(bootstrapHelper.HtmlHelper, select);
        }
    }
}
