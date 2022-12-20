﻿using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FBootstrapCoreMvc.Extensions
{
    public static class FormExtensions
    {
        public static BootstrapContent<Form, TModel> SetAction<TModel>(this BootstrapContent<Form, TModel> content, string action, string controller, object? routeValues = null)
        {
            var url = content.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            content.Component.SetAction(url);
            return content;
        }

        public static BootstrapContent<Form, TModel> SetFormMethod<TModel>(this BootstrapContent<Form, TModel> content, FormMethod formMethod)
        {
            content.Component.SetMethod(formMethod.ToString());
            return content;
        }

        public static BootstrapContent<Form, TModel> SetConfirm<TModel>(this BootstrapContent<Form, TModel> content, string message)
        {
            content.Component.SetConfirm(message);
            return content;
        }

        public static BootstrapContent<FormInput> Input<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string? name = null, string? label = null, object? value = null, FormInputType inputType = FormInputType.Text)
            where TComponent : HtmlComponent, ICanCreate<FormInput>
        {
            var input = new FormInput();
            input.SetType(inputType)
                .SetName(name)
                .SetValue(value)
                .SetPlaceholder(label);
            return new BootstrapContent<FormInput>(builder.HtmlHelper, input);
        }

        public static BootstrapContent<HtmlElement> DisplayFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<FormInput>
        {
            throw new NotImplementedException();
        }

        public static BootstrapContent<HtmlElement> EditorFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<FormInput>
        {
            throw new NotImplementedException();
        }

        public static BootstrapContent<FormCheck> CheckFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<FormCheck>
        {
            var modelExpressionProvider = builder.HtmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(builder.HtmlHelper.ViewData, expression);
            var formCheck = new FormCheck(modelExpression.Name, modelExpression.Name, modelExpression.Model as bool?);
            return new BootstrapContent<FormCheck>(builder.HtmlHelper, formCheck);
        }

        public static BootstrapContent<FormInput> InputFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<FormInput>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var input = new FormInput();
            input.SetName(modelExpression.Name);
            input.SetPlaceholder(modelExpression.Name);
            if (modelExpression.Model != null)
                input.SetValue((TValue)modelExpression.Model);
            return new BootstrapContent<FormInput>(builder.HtmlHelper, input);
        }

        public static BootstrapContent<FormInput> PasswordFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<FormInput>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var input = new FormInput();
            input.SetPlaceholder(modelExpression.Name)
                .SetType(FormInputType.Password)
                .SetName(modelExpression.Name);
            return new BootstrapContent<FormInput>(builder.HtmlHelper, input);
        }

        public static IHtmlContent HiddenFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<FormInput>
        {
            return builder.HtmlHelper.HiddenFor(expression);
        }

        public static BootstrapContent<Label> LabelFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : HtmlComponent, ICanCreate<Label>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var label = new Label();
            label.MergeAttribute("for", modelExpression.Name);
            label.SetContent(modelExpression.Name);
            return new BootstrapContent<Label>(htmlHelper, label);
        }

        public static BootstrapContent<FormSelect> SelectFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
            where TComponent : HtmlComponent, ICanCreate<FormSelect>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var formSelect = new FormSelect(modelExpression.Name)
            {
                Name = modelExpression.Name,
                SelectList = selectList,
                SelectedValue = modelExpression.Model
            };
            return new BootstrapContent<FormSelect>(htmlHelper, formSelect);
        }

        public static BootstrapContent<FormSelect> Select<TComponent>(this BootstrapBuilder<TComponent> builder, string name, IEnumerable<SelectListItem> selectList, string? label = null)
            where TComponent : HtmlComponent, ICanCreate<FormSelect>
        {
            var formSelect = new FormSelect(label)
            {
                Name = name,
                SelectList = selectList
            };
            return new BootstrapContent<FormSelect>(builder.HtmlHelper, formSelect);
        }

        public static BootstrapContent<FormCheck> CheckBox<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string? name = null, string? label = null, string? description = null, bool isChecked = false)
            where TComponent : HtmlComponent, ICanCreate<FormCheck>
        {
            var checkbox = new FormCheck(name, label, isChecked);
            return new BootstrapContent<FormCheck>(builder.HtmlHelper, checkbox);
        }

        public static BootstrapContent<Button> Button<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string text = "Button", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : HtmlComponent, ICanCreate<Button>
        {
            var button = new Button(text)
            {
                ButtonType = ButtonType.Button
            };
            if (value != null)
                button.SetValue(value.ToString());
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }

        public static BootstrapContent<Button> Submit<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string text = "Submit", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : HtmlComponent, ICanCreate<Button>
        {
            var submit = new Button(text)
            {
                ButtonState = buttonState,
                ButtonType = ButtonType.Submit
            };
            if (value != null)
                submit.SetValue(value.ToString());
            return new BootstrapContent<Button>(builder.HtmlHelper, submit);
        }

        public static BootstrapContent<Button> Reset<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string text = "Reset", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : HtmlComponent, ICanCreate<Button>
        {
            var reset = new Button(text)
            {
                ButtonState = buttonState,
                ButtonType = ButtonType.Reset
            };
            if (value != null)
                reset.SetValue(value.ToString());
            return new BootstrapContent<Button>(builder.HtmlHelper, reset);
        }
    }
}
