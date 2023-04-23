﻿
using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using FBootstrapCoreMvc.Options;
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
        public static BootstrapContent<Form, TModel> Action<TModel>(this BootstrapContent<Form, TModel> content, string action, string controller, object? routeValues = null)
        {
            var url = content.HtmlHelper.GetUrlHelper().Action(action, controller, routeValues);
            content.Component.Action = url;
            return content;
        }

        public static BootstrapContent<Form, TModel> FormMethod<TModel>(this BootstrapContent<Form, TModel> content, FormMethod formMethod)
        {
            content.Component.Method = formMethod.ToString();
            return content;
        }

        public static BootstrapContent<Form, TModel> Confirm<TModel>(this BootstrapContent<Form, TModel> content, string message)
        {
            content.Component.ConfirmMessage = message;
            return content;
        }

        #region Form Components
        public static BootstrapContent<FormInput> Input<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string? name = null, string? label = null, object? value = null, FormInputType inputType = FormInputType.Text)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {
            var input = new FormInput
            {
                Type = inputType,
                Name = name,
                Value = value,
                Placeholder = label
            };
            return new BootstrapContent<FormInput>(builder.HtmlHelper, input);
        }

        public static BootstrapContent<FormInput> InputFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var input = new FormInput
            {
                Name = modelExpression.Name,
                Placeholder = modelExpression.Name
            };
            if (modelExpression.Model != null)
                input.Value = (TValue)modelExpression.Model;
            return new BootstrapContent<FormInput>(builder.HtmlHelper, input);
        }

        public static BootstrapContent<FormTextArea> TextArea<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string? name = null, string? label = null, object? value = null)
            where TComponent : Form
        {
            var textarea = new FormTextArea
            {
                Name = name,
                Value = value,
                Placeholder = label,
                Content = value
            };
            return new BootstrapContent<FormTextArea>(builder.HtmlHelper, textarea);
        }

        public static BootstrapContent<FormTextArea> TextAreaFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : Form
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);

            var textarea = new FormTextArea
            {
                Name = modelExpression.Name,
                Placeholder = modelExpression.Name
            };

            if (modelExpression.Model != null)
                textarea.Content = (TValue)modelExpression.Model;

            return new BootstrapContent<FormTextArea>(builder.HtmlHelper, textarea);
        }

        public static BootstrapContent<HtmlElement> DisplayFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {
            throw new NotImplementedException();
        }

        public static BootstrapContent<HtmlElement> EditorFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {
            throw new NotImplementedException();
        }

        public static BootstrapContent<FormCheck> CheckBox<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string? name = null, string? label = null, bool isChecked = false)
            where TComponent : SingleComponent, ICanCreate<FormCheck>
        {
            var formCheck = new FormCheck
            {
                Name = name,
                Label = label,
                Checked = isChecked
            };
            return new BootstrapContent<FormCheck>(builder.HtmlHelper, formCheck);
        }

        public static BootstrapContent<FormCheck> CheckFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<FormCheck>
        {
            var modelExpressionProvider = builder.HtmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(builder.HtmlHelper.ViewData, expression);

            var formCheck = new FormCheck
            {
                Name = modelExpression.Name,
                Label = modelExpression.Name,
            };
            if (modelExpression.Model is bool checkedVal)
            {
                formCheck.Checked = checkedVal;
            }
            return new BootstrapContent<FormCheck>(builder.HtmlHelper, formCheck);
        }

        public static BootstrapContent<FormInput> Password<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string? name = null, string? label = null)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {

            return builder.Input(name, label, null, FormInputType.Password);
        }

        public static BootstrapContent<FormInput> PasswordFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var input = new FormInput
            {
                Placeholder = modelExpression.Name,
                Type = FormInputType.Password,
                Name = modelExpression.Name
            };
            return new BootstrapContent<FormInput>(builder.HtmlHelper, input);
        }

        public static IHtmlContent HiddenFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<FormInput>
        {
            return builder.HtmlHelper.HiddenFor(expression);
        }

        public static BootstrapContent<Label> LabelFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : SingleComponent, ICanCreate<Label>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var label = new Label
            {
                Content = modelExpression.Name,
                For = modelExpression.Name
            };
            return new BootstrapContent<Label>(htmlHelper, label);
        }

        public static BootstrapContent<FormSelect> Select<TComponent>(this BootstrapBuilder<TComponent> builder, string name, IEnumerable<SelectListItem> selectList)
            where TComponent : SingleComponent, ICanCreate<FormSelect>
        {
            var formSelect = new FormSelect()
            {
                Name = name,
                SelectList = selectList
            };
            return new BootstrapContent<FormSelect>(builder.HtmlHelper, formSelect);
        }

        public static BootstrapContent<FormSelect> SelectFor<TComponent, TModel, TValue>(this BootstrapBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
            where TComponent : SingleComponent, ICanCreate<FormSelect>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var formSelect = new FormSelect()
            {
                Name = modelExpression.Name,
                SelectList = selectList,
                SelectedValue = modelExpression.Model
            };
            return new BootstrapContent<FormSelect>(htmlHelper, formSelect);
        }

        public static BootstrapContent<Button> Button<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string text = "Button", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : SingleComponent, ICanCreate<Button>
        {
            var button = new Button()
            {
                Content = text,
                ButtonType = ButtonType.Button,
                Value = value
            };
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }

        public static BootstrapContent<Button> Submit<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string text = "Submit", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : SingleComponent, ICanCreate<Button>
        {
            var submit = new Button()
            {
                Content = text,
                ButtonState = buttonState,
                ButtonType = ButtonType.Submit,
                Value = value
            };
            return new BootstrapContent<Button>(builder.HtmlHelper, submit);
        }

        public static BootstrapContent<Button> Reset<TComponent, TModel>(this BootstrapBuilder<TComponent, TModel> builder, string text = "Reset", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : SingleComponent, ICanCreate<Button>
        {
            var reset = new Button()
            {
                Content = text,
                ButtonState = buttonState,
                ButtonType = ButtonType.Reset,
                Value = value
            };
            return new BootstrapContent<Button>(builder.HtmlHelper, reset);
        }
        #endregion

        public static BootstrapContent<TComponent> InputOpts<TComponent, TInput>(this BootstrapContent<TComponent> bootstrapContent, IUtilityOptions opts)
            where TComponent : FormControl<TInput>
            where TInput : BootstrapComponent, IInputComponent
        {
            if (bootstrapContent.Component.InputOpts == null)
                bootstrapContent.Component.InputOpts = new OptionList();
            bootstrapContent.Component.InputOpts.Add(opts);
            return bootstrapContent;
        }

        public static BootstrapContent<FormInput> InputOpts(this BootstrapContent<FormInput> bootstrapContent, IUtilityOptions opts) => bootstrapContent.InputOpts<FormInput, Input>(opts);

        public static BootstrapContent<TComponent> InputCss<TComponent, TInput>(this BootstrapContent<TComponent> bootstrapContent, params string[] cssClasses)
            where TComponent : FormControl<TInput>
            where TInput : BootstrapComponent, IInputComponent
        {
            bootstrapContent.Component.Input.AddCss(cssClasses);
            return bootstrapContent;
        }

        public static BootstrapContent<FormInput> InputCss(this BootstrapContent<FormInput> bootstrapContent, params string[] cssClasses) => bootstrapContent.InputCss<FormInput, Input>(cssClasses);

        public static BootstrapContent<TComponent> FloatingLabel<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? label)
            where TComponent : SingleComponent, ICanHaveFloatingLabel
        {
            bootstrapContent.Component.FloatingLabel = label;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Label<TComponent>(this BootstrapContent<TComponent> bootstrapContent, string? label)
            where TComponent : SingleComponent, ICanHaveLabel
        {
            bootstrapContent.Component.Label = label;
            return bootstrapContent;
        }

        public static BootstrapContent<TComponent> Invalid<TComponent>(this BootstrapContent<TComponent> bootstrapContent)
            where TComponent : SingleComponent, ICanBeInvalid
        {
            bootstrapContent.Component.Invalid = true;
            return bootstrapContent;
        }
    }
}
