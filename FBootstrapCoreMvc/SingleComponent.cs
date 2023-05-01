using FluentBootstrapCore.Enums;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;

namespace FluentBootstrapCore
{
    public abstract class SingleComponent : HtmlComponent
    {
        #region Props&Fields
        private object? _content;
        private readonly TagBuilder _tagBuilder;
        private readonly List<(ChildLocation, SingleComponent)> _children;

        private RenderMode _renderMode;

        public string? Id { get; protected internal set; }
        public string Tag => _tagBuilder.TagName;

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
        public bool IsContentHtml { get; set; }
        public HashSet<string> CssClasses { get; private set; }

        public Dictionary<string, object> Styles { get; private set; }

        #endregion

        #region Ctors
        public SingleComponent(string tagName, params string[] cssClasses)
        {
            _tagBuilder = new TagBuilder(tagName);
            _renderMode = RenderMode.Normal;
            CssClasses = new HashSet<string>();
            Styles = new Dictionary<string, object>();
            if (cssClasses.Any())
                AddCss(cssClasses);
            _children = new List<(ChildLocation, SingleComponent)>();
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

        #region DOM Methods
        public void AddCss(params string[] cssClasses)
        {
            foreach (var cssClass in cssClasses)
            {
                if (!string.IsNullOrWhiteSpace(cssClass))
                    CssClasses.Add(cssClass);
            }
        }
        public void AddCss(IEnumerable<string> cssClasses)
        {
            foreach (var cssClass in cssClasses)
            {
                if (!string.IsNullOrWhiteSpace(cssClass))
                    CssClasses.Add(cssClass);
            }
        }

        public void ClearCss()
        {
            CssClasses.Clear();
        }

        public void RemoveCss(params string[] cssClasses)
        {
            foreach (var cssClass in cssClasses)
                CssClasses.Remove(cssClass);
        }

        public void MergeStyle(string key, object value)
        {
            Styles.Add(key, value);
        }

        /// <summary>
        /// Replaces '_' char with '-'
        /// </summary>
        /// <param name="styles"></param>
        public void MergeStyle(object styles)
        {
            foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(styles))
            {
                var key = property.Name.ToLowerInvariant().Replace("_", "-");
                var value = Convert.ToString(property.GetValue(styles), CultureInfo.InvariantCulture);
                Styles.Add(key, value);
            }
        }
        #endregion

        public override string ToHtml()
        {
            if (RenderMode == RenderMode.None)
                return string.Empty;

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
        protected virtual void PreBuild()
        {
            if (CssClasses.Any())
            {
                foreach (var cssClass in CssClasses)
                {
                    _tagBuilder.AddCssClass(cssClass);
                }
            }

            if (Styles.Any())
            {
                var style = string.Join(";", Styles.Select(s => $"{s.Key}:{s.Value}"));
                MergeAttribute("style", style, true);
            }

            if (Id != null)
                MergeAttribute("id", Id);
        }

        internal IHtmlContent Begin()
        {
            PreBuild();

            var fullWrapperChildren = _children.Where(c => c.Item1 == ChildLocation.FullWrap)
                                               .Select(c => c.Item2)
                                               .ToList();

            fullWrapperChildren.ForEach(c => _tagBuilder.InnerHtml.AppendHtml(c.ToHtml()));

            var headerChildren = _children.Where(c => c.Item1 == ChildLocation.Header)
                                          .Select(c => c.Item2)
                                          .ToList();

            foreach (var child in headerChildren)
            {
                _tagBuilder.InnerHtml.AppendHtml(child.ToHtml());
            }
            return _tagBuilder.RenderStartTag();
        }

        internal IHtmlContent Body()
        {
            var bodyWrapperChildren = _children.Where(c => c.Item1 == ChildLocation.BodyWrap)
                                               .Select(c => c.Item2)
                                               .ToList();

            bodyWrapperChildren.ForEach(c => _tagBuilder.InnerHtml.AppendHtml(c.ToHtml()));

            AppendContent(_content, false, IsContentHtml);
            var bodyChildren = _children.Where(c => c.Item1 == ChildLocation.Body)
                                        .Select(c => c.Item2)
                                        .ToList();
            bodyChildren.ForEach(c => _tagBuilder.InnerHtml.AppendHtml(c.ToHtml()));

            return _tagBuilder.RenderBody();
        }

        internal IHtmlContent End()
        {
            var htmlContentBuilder = new HtmlContentBuilder();

            var bodyWrapperChildren = _children.Where(c => c.Item1 == ChildLocation.BodyWrap)
                                               .Select(c => c.Item2)
                                               .ToList();

            foreach (var wrapper in bodyWrapperChildren.Reverse<SingleComponent>())
            {
                var clone = wrapper.Clone();
                clone.RenderMode = RenderMode.End;
                _tagBuilder.InnerHtml.AppendHtml(clone.ToHtml());
                htmlContentBuilder.AppendHtml(clone.ToHtml());
            }

            var footerChildren = _children.Where(c => c.Item1 == ChildLocation.Footer)
                                   .Select(c => c.Item2)
                                   .ToList();

            foreach (var child in footerChildren)
            {
                _tagBuilder.InnerHtml.AppendHtml(child.ToHtml());
                htmlContentBuilder.AppendHtml(child.ToHtml());
            }

            var fullWrapperChildren = _children.Where(c => c.Item1 == ChildLocation.FullWrap)
                                   .Select(c => c.Item2)
                                   .ToList();

            foreach (var wrapper in fullWrapperChildren.Reverse<SingleComponent>())
            {
                var clone = wrapper.Clone();
                clone.RenderMode = RenderMode.End;
                _tagBuilder.InnerHtml.AppendHtml(clone.ToHtml());
                htmlContentBuilder.AppendHtml(clone.ToHtml());
            }
            htmlContentBuilder.AppendHtml(_tagBuilder.RenderEndTag());
            return htmlContentBuilder;
        }

        protected internal void AddChild(SingleComponent? component, ChildLocation childType = ChildLocation.Body)
        {
            if (component == null) return;
            if (childType.Equals(ChildLocation.FullWrap) || childType.Equals(ChildLocation.BodyWrap))
                component.RenderMode = RenderMode.Start;

            _children.Add((childType, component));
        }

        protected internal void RemoveChild(SingleComponent component)
        {
            if (component == null) return;
            _children.RemoveAll(c => c.Item2 == component);
        }

        protected internal void AppendContent(object? content, bool clear = false, bool isHtml = false)
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
            if (isHtml)
            {
                _tagBuilder.InnerHtml.AppendHtml(content.ToString());
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

        protected TComponent GetChild<TComponent>()
        {
            throw new NotImplementedException();
        }

        //[Obsolete("Use AddChild instead.")]
        //protected void AddWrappingChild<TComponent>(TComponent component, WrapperType wrapperType = WrapperType.All)
        //    where TComponent : SingleComponent
        //{
        //    var loc = wrapperType switch
        //    {
        //        WrapperType.Body => ChildLocation.BodyWrap,
        //        _ => ChildLocation.FullWrap,
        //    };
        //    AddChild(component, loc);
        //}

        public TComponent Clone<TComponent>()
            where TComponent : SingleComponent
        {
            return (TComponent)MemberwiseClone();
        }

        public SingleComponent Clone()
        {
            return Clone<SingleComponent>();
        }

        protected internal void GenerateId()
        {
            Id = $"{Tag}_{DateTime.Now.Ticks}";
        }
        #endregion
    }
}
