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
        private readonly List<IHtmlComponent> _headerChildren;
        private readonly List<IHtmlComponent> _bodyChildren;
        private readonly List<IHtmlComponent> _footerChildren;

        private RenderMode _renderMode;

        public string? Id { get; protected internal set; }

        internal object? Content
        {
            get => _content;
            set => _content = value;
        }
        internal RenderMode RenderMode
        {
            get => _renderMode;
            set => _renderMode = value;
        }
        #endregion

        #region Ctors
        public HtmlComponent(string tagName, params string[] cssClasses)
        {
            _tagBuilder = new TagBuilder(tagName);
            _renderMode = RenderMode.Normal;
            _tagBuilder.AddCssClass(string.Join(" ", cssClasses));
            _headerChildren = new List<IHtmlComponent>();
            _bodyChildren = new List<IHtmlComponent>();
            _footerChildren = new List<IHtmlComponent>();
        }

        #endregion

        #region Methods
        private void SetTagRenderMode()
        {
            switch (RenderMode)
            {
                case RenderMode.Start:
                    _tagBuilder.TagRenderMode = TagRenderMode.StartTag;
                    break;
                case RenderMode.End:
                    _tagBuilder.TagRenderMode = TagRenderMode.EndTag;
                    break;
                case RenderMode.SelfClosing:
                    _tagBuilder.TagRenderMode = TagRenderMode.SelfClosing;
                    break;
            }
        }

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

        protected internal void MergeStyle(string key, string value)
        {
            _tagBuilder.MergeAttribute("style", $"{key}:{value};", false);
        }

        /// <summary>
        /// Replaces '_' char with '-'
        /// </summary>
        /// <param name="styles"></param>
        protected internal void MergeStyles(object styles)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(styles))
            {
                var key = property.Name.ToLowerInvariant().Replace("_", "-");
                var value = Convert.ToString(property.GetValue(styles), CultureInfo.InvariantCulture);
                MergeStyle(key, value);
            }
        }

        public string ToHtml()
        {
            Build();
            SetTagRenderMode();
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
            if (Id != null)
                MergeAttribute("id", Id);
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

        internal IHtmlContent Body()
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

        protected internal void AddChild(IHtmlComponent? component, ChildLocation childType = ChildLocation.Body)
        {
            if (component == null) return;

            switch (childType)
            {
                case ChildLocation.Header:
                    _headerChildren.Add(component);
                    break;
                case ChildLocation.Body:
                    _bodyChildren.Add(component);
                    break;
                case ChildLocation.Footer:
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

        protected internal void AppendHtml(string? htmlString, bool clear = false)
        {
            if (htmlString == null)
                return;

            if (clear)
                _tagBuilder.InnerHtml.Clear();

            _tagBuilder.InnerHtml.AppendHtml(htmlString);
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
