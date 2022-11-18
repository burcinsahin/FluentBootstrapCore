using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FBootstrapCoreMvc
{
    [Obsolete("Use HtmlComponent instead.")]
    public class Component : TagBuilder
    {
        private readonly IHtmlHelper _helper;

        protected List<Component> _childComponents;
        protected internal string Id
        {
            get => Attributes["id"];
            set => MergeAttribute("id", value, true);
        }

        public Component(IHtmlHelper helper, string tagName, params string[] cssClasses)
            : base(tagName)
        {
            _helper = helper;
            _childComponents = new List<Component>();

            foreach (var cssClass in cssClasses)
            {
                AddCssClass(cssClass);
            }
        }

        //protected internal void SetId(string? id = null)
        //{
        //    if (id == null)
        //        id = $"{GetType().Name}_{DateTime.Now.Ticks}";
        //    MergeAttribute("id", id, true);
        //}

        protected internal void AppendContent(object? content, bool clearHtml = false)
        {
            if (content == null) return;
            if (clearHtml)
                InnerHtml.Clear();
            if (content is IHtmlContent htmlContent)
                InnerHtml.AppendHtml(htmlContent);
            else
                InnerHtml.Append(content.ToString());
        }

        protected void Write(IHtmlContent htmlContent)
        {
            _helper.ViewContext.Writer.Write(htmlContent);
        }

        protected virtual void End()
        {
            _helper.ViewContext.Writer.Write(RenderEndTag());
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }

        /// <summary>
        /// Appends child components to inner html
        /// </summary>
        /// <param name="clearHtml">if true, clears inner html before appending</param>
        protected internal void AppendChildrenToHtml(bool clearHtml = false)
        {
            if (clearHtml)
                InnerHtml.Clear();
            foreach (var comp in _childComponents)
            {
                InnerHtml.AppendHtml(comp);
            }
        }
    }
}
