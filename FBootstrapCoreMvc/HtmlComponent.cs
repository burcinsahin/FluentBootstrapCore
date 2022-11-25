using FBootstrapCoreMvc.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace FBootstrapCoreMvc
{
    public abstract class HtmlComponent : IHtmlComponent
    {
        #region Props&Fields
        private object? _content;
        private readonly TagBuilder _tagBuilder;
        private List<IHtmlComponent> _headerChildren;
        private List<IHtmlComponent> _bodyChildren;
        private List<IHtmlComponent> _footerChildren;

        public string? Id { get; protected internal set; }

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

        protected internal void AddStyle(string key, string value)
        {
            _tagBuilder.MergeAttribute("style", $"{key}:{value};", false);
        }

        protected internal void AddStyles(object styles)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(styles))
            {
                var key = property.Name;
                var value = Convert.ToString(property.GetValue(styles), CultureInfo.InvariantCulture);
                AddStyle(key, value);
            }
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

        protected internal void AddChild(IHtmlComponent? component, ChildType childType = ChildType.Body)
        {
            if (component == null) return;

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

        protected internal void RemoveChild(IHtmlComponent component)
        {
            if (component == null) return;
            _headerChildren.Remove(component);
            _bodyChildren.Remove(component);
            _footerChildren.Remove(component);
        }

        protected internal void AppendContent(object? content, bool clear = false)
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
            if (content is IHtmlContent htmlContent)
            {
                _tagBuilder.InnerHtml.AppendHtml(htmlContent);
                return;
            }
            _tagBuilder.InnerHtml.Append(content.ToString());
        }

        protected internal void MergeAttribute(string key, object? value = null, bool replaceExisting = false)
        {
            if (value == null)
            {
                _tagBuilder.MergeAttribute(key, null, true);
                return;
            }

            _tagBuilder.MergeAttribute(key, value.ToString(), replaceExisting);
        }

        protected internal string? GetAttribute(string key)
        {
            _tagBuilder.Attributes.TryGetValue(key, out var attr);
            return attr;
        }
        #endregion
    }
}
