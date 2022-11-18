using FBootstrapCoreMvc.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;

namespace FBootstrapCoreMvc
{
    public class HtmlComponent : IHtmlComponent
    {
        #region Props&Fields
        private object? _content;
        private readonly TagBuilder _tagBuilder;
        private List<IHtmlComponent> _headerChildren;
        private List<IHtmlComponent> _bodyChildren;
        private List<IHtmlComponent> _footerChildren;

        internal object? Content { get => _content; set => _content = value; } 
        #endregion

        #region Ctors
        public HtmlComponent(string tagName, params string[] cssClasses)
        {
            _tagBuilder = new TagBuilder(tagName);
            _tagBuilder.AddCssClass(string.Join(" ", cssClasses));
            _headerChildren = new List<IHtmlComponent>();
            _bodyChildren = new List<IHtmlComponent>();
            _footerChildren = new List<IHtmlComponent>();
        }
        #endregion

        #region Methods
        protected internal void AddCss(params string[] cssClasses)
        {
            foreach (var cssClass in cssClasses)
            {
                _tagBuilder.AddCssClass(cssClass);
            }
        }

        protected internal void ClearCss()
        {
            _tagBuilder.Attributes.Remove("class");
        }

        protected internal void RemoveCss(params string[] cssClasses)
        {
            if (!_tagBuilder.Attributes.ContainsKey("class"))
                return;
            var currentClasses = _tagBuilder.Attributes["class"]
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            ClearCss();
            AddCss(currentClasses.Except(cssClasses).ToArray());
        }

        public string ToHtml()
        {
            Build();
            return _tagBuilder.ToHtmlString();
        }

        private void Build()
        {
            Begin();
            Body();
            End();
        }

        /// <summary>
        /// Invoked before Begin
        /// </summary>
        protected virtual void Initialize()
        {
        }

        internal IHtmlContent Begin()
        {
            Initialize();
            foreach (var child in _headerChildren)
            {
                _tagBuilder.InnerHtml.AppendHtml(child.ToHtml());
            }
            return _tagBuilder.RenderStartTag();
        }

        internal IHtmlContent Body()//TODO: virtual??
        {
            AppendContent(_content);
            _bodyChildren.ForEach(c => _tagBuilder.InnerHtml.AppendHtml(c.ToHtml()));
            return _tagBuilder.RenderBody();
        }

        internal IHtmlContent End()
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            foreach (var child in _footerChildren)
            {
                _tagBuilder.InnerHtml.AppendHtml(child.ToHtml());
                htmlContentBuilder.AppendHtml(child.ToHtml());
            }
            htmlContentBuilder.AppendHtml(_tagBuilder.RenderEndTag());
            return htmlContentBuilder;
        }

        internal void AddChild(IHtmlComponent component, ChildType childType = ChildType.Body)
        {
            switch (childType)
            {
                case ChildType.Header:
                    _headerChildren.Add(component);
                    break;
                case ChildType.Body:
                    _bodyChildren.Add(component);
                    break;
                case ChildType.Footer:
                    _footerChildren.Add(component);
                    break;
            }
        }

        internal void AppendContent(object? content, bool clear = false)
        {
            if (content == null)
                return;

            if (clear)
                _tagBuilder.InnerHtml.Clear();

            if (content is IHtmlComponent htmlComponent)
            {
                _tagBuilder.InnerHtml.AppendHtml(htmlComponent.ToHtml());
                return;
            }
            _tagBuilder.InnerHtml.Append(content.ToString());
        }

        internal void MergeAttribute(string key, object? value = null, bool replaceExisting = false)
        {
            if (value == null)
            {
                _tagBuilder.MergeAttribute(key, null, true);
                return;
            }

            _tagBuilder.MergeAttribute(key, value.ToString(), replaceExisting);
        }
        #endregion
    }
}
