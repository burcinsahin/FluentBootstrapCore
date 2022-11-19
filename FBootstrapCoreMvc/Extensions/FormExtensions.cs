using FBootstrapCoreMvc;
using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;
using FBootstrapCoreMvc.Extensions;
using FBootstrapCoreMvc.Interfaces;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FBootstrapCoreMvc.Extensions
{
    public static class FormExtensions
    {
        public static Form<TModel> SetAction<TModel>(this Form<TModel> component, string action, string controller, object? routeValues = null)
        {
            var url = component.Helper.GetUrlHelper().Action(action, controller, routeValues);
            component.SetAction(url);
            return component;
        }

        public static Form<TModel> SetFormMethod<TModel>(this Form<TModel> component, FormMethod formMethod)
        {
            component.SetMethod(formMethod.ToString());
            return component;
        }


        public static Icon FormIcon<TComponent>(this HtmlBuilder<TComponent> builder)
            where TComponent : Component<TComponent>, ICanCreate<Icon>
        {
            return new Icon(IconType.Chat);
        }

        public static FormInput Input<TComponent, TModel>(this MvcBuilder<TComponent, TModel> builder, string? name = null, string? label = null, object? value = null, FormInputType inputType = FormInputType.Text)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormInput>
        {
            var input = new FormInput(builder.HtmlHelper);
            input.SetType(inputType)
                .SetName(name)
                .SetValue(value)
                .SetPlaceholder(label);
            return input;
        }

        public static Component DisplayFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormInput>
        {
            throw new NotImplementedException();
        }

        public static Component EditorFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormInput>
        {
            throw new NotImplementedException();
        }

        public static FormCheck CheckFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormCheck>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var formCheck = new FormCheck(builder.HtmlHelper, modelExpression.Name, modelExpression.Name, modelExpression.Model as bool?);
            return formCheck;
        }

        public static FormInput InputFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormInput>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var input = new FormInput(builder.HtmlHelper);
            input.SetName(modelExpression.Name);
            input.SetPlaceholder(modelExpression.Name);
            if (modelExpression.Model != null)
                input.SetValue((TValue)modelExpression.Model);
            return input;
        }

        public static FormInput PasswordFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormInput>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var input = new FormInput(builder.HtmlHelper);
            return input.SetPlaceholder(modelExpression.Name)
                .SetType(FormInputType.Password)
                .SetName(modelExpression.Name);
        }

        public static IHtmlContent HiddenFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormInput>
        {
            return builder.HtmlHelper.HiddenFor(expression);
        }

        public static Label LabelFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<Label>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var label = new Label(builder.HtmlHelper)
                .AddAttribute("for", modelExpression.Name)
                .SetContent(modelExpression.Name);
            return label;
        }

        public static FormSelect SelectFor<TComponent, TModel, TValue>(this MvcBuilder<TComponent, TModel> builder, Expression<Func<TModel, TValue>> expression, IEnumerable<SelectListItem> selectList)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormSelect>
        {
            var htmlHelper = builder.HtmlHelper;
            var modelExpressionProvider = htmlHelper.GetModelExpressionProvider();
            var modelExpression = modelExpressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var formSelect = new FormSelect(builder.HtmlHelper, modelExpression.Name);
            formSelect.SetName(modelExpression.Name);
            formSelect.SetOptions(selectList);
            return formSelect;
        }


        public static FormSelect Select<TComponent, TModel>(this MvcBuilder<TComponent, TModel> builder, string name, string label, IEnumerable<SelectListItem> selectList)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormSelect>
        {
            var formSelect = new FormSelect(builder.HtmlHelper, label);
            formSelect.SetName(name);
            formSelect.SetOptions(selectList);
            return formSelect;
        }

        public static FormCheck CheckBox<TComponent, TModel>(this MvcBuilder<TComponent, TModel> builder, string name = null, string label = null, string description = null, bool isChecked = false)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<FormCheck>
        {
            var checkbox = new FormCheck(builder.HtmlHelper, name, label, isChecked);
            return checkbox;
        }

        public static Button Button<TComponent, TModel>(this MvcBuilder<TComponent, TModel> builder, string text = "Button", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<Button>
        {
            var button = new Button(buttonState, text);
            button.SetType(ButtonType.Button);
            if (value != null)
                button.SetValue(value.ToString());
            return button;
        }

        public static Button Submit<TComponent, TModel>(this MvcBuilder<TComponent, TModel> builder, string text = "Submit", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<Button>
        {
            var submit = new Button(buttonState, text);
            submit.SetType(ButtonType.Submit);
            if (value != null)
                submit.SetValue(value.ToString());
            return submit;
        }

        public static Button Reset<TComponent, TModel>(this MvcBuilder<TComponent, TModel> builder, string text = "Reset", ButtonState buttonState = ButtonState.Primary, object? value = null)
            where TComponent : MvcComponent<TComponent, TModel>, ICanCreate<Button>
        {
            var reset = new Button(buttonState, text);
            reset.SetType(ButtonType.Reset);
            if (value != null)
                reset.SetValue(value.ToString());
            return reset;
        }
    }
}
