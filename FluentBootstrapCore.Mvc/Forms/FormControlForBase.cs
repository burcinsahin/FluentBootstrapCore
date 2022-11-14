using FluentBootstrapCore.Forms;
using FluentBootstrapCore.Html;
using FluentBootstrapCore.Internals;
using FluentBootstrapCore.Mvc.Internals;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq.Expressions;

namespace FluentBootstrapCore.Mvc.Forms
{
    public abstract class FormControlForBase : FormControl
    {
        public bool AddDescription { get; set; }
        public bool AddValidationMessage { get; set; }
        public bool AddHidden { get; set; }   // No effect if Editor == true
        public bool AddFormControlClass { get; set; }  // No effect if Editor == false
        public string TemplateName { get; set; }
        public object AdditionalViewData { get; set; }

        protected FormControlForBase(BootstrapHelper helper, bool editor)
            : base(helper, "div", editor ? null : " "/*Css.FormControlStatic*/)
        {
            AddFormControlClass = true;
        }
    }

    public abstract class FormControlForBase<TModel, TValue> : FormControlForBase
    {
        private readonly bool _editor;
        protected Expression<Func<TModel, TValue>> Expression { get; private set; }


        protected FormControlForBase(BootstrapHelper helper, bool editor, Expression<Func<TModel, TValue>> expression)
            : base(helper, editor)
        {
            _editor = editor;
            Expression = expression;
        }

        protected override void OnStart(TextWriter writer)
        {
            base.OnStart(writer);

            if (_editor)
            {
                WriteEditor(writer);
            }
            else
            {
                WriteDisplay(writer);
            }

            // Add the validation message if requested
            if (AddValidationMessage)
            {
                writer.Write(this.GetHtmlHelper<TModel>().ValidationMessageFor(Expression, "", null, "").ToHtmlString());//TODO:???
            }
        }

        protected override void OnFinish(TextWriter writer)
        {
            // Add the description text if requested
            if (AddDescription)
            {
                var htmlHelper = this.GetHtmlHelper<TModel>();
                var expressionProvider = htmlHelper.GetModelExpressionProvider();
                var metadata = expressionProvider.CreateModelExpression(htmlHelper.ViewData, Expression).Metadata;
                if (!string.IsNullOrWhiteSpace(metadata.Description))
                {
                    Element element = GetHelper().Element("p").AddCss(/*Css.HelpBlock*/).GetComponent();
                    element.AddChild(GetHelper().Content(metadata.Description));
                    element.StartAndFinish(writer);
                }
            }

            base.OnFinish(writer);
        }

        protected virtual void WriteDisplay(TextWriter writer)
        {
            //// Insert the hidden control if requested
            if (AddHidden)
            {
                this.GetHelper<TModel>().HiddenFor(Expression).GetComponent().StartAndFinish(writer);
            }

            writer.Write(this.GetHtmlHelper<TModel>().DisplayFor(Expression, TemplateName, AdditionalViewData));
        }

        protected virtual void WriteEditor(TextWriter writer)
        {
            var htmlHelper = this.GetHtmlHelper<TModel>();
            var editor = htmlHelper.EditorFor(Expression, TemplateName, AdditionalViewData);
            writer.Write(GetEditor(editor.ToHtmlString()));
        }

        protected string? GetEditor(string? html)
        {
            if (AddFormControlClass)
            {
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);
                bool addedFormControl = false;
                foreach (HtmlNode node in doc.DocumentNode.ChildNodes)
                {
                    if ((node.Name == "input" && (!node.Attributes.Contains("type")
                        || (node.Attributes["type"].Value != "hidden"
                        && node.Attributes["type"].Value != "radio"
                        && node.Attributes["type"].Value != "checkbox")))
                        || node.Name == "textarea"
                        || node.Name == "select")
                    {
                        if (node.Attributes.Contains("class"))
                            node.Attributes["class"].Value += " form-control";
                        else
                            node.Attributes.Add("class", "form-control");
                        addedFormControl = true;
                    }
                    else if (node.Name == "script" && node.InnerHtml.Contains("kendo"))
                    {
                        // Don't set the form-control class for Kendo controls
                        addedFormControl = false;
                        break;
                    }
                }
                if (addedFormControl)
                {
                    html = doc.DocumentNode.OuterHtml;
                }
            }
            return html;
        }
    }
}
