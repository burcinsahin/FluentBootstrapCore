using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FBootstrapCoreMvc
{
    public class Component : TagBuilder, IDisposable
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

        protected void SetContent(object? content)
        {
            if (content == null) return;
            if (content is IHtmlContent htmlContent)
                InnerHtml.SetHtmlContent(htmlContent);
            else
                InnerHtml.SetContent(content.ToString());
        }

        public virtual void End()
        {
            Finish();
            _helper.ViewContext.Writer.Write(RenderEndTag());
        }

        public void Dispose()
        {
            End();
        }

        public override string ToString()
        {
            return this.ToHtmlString();
        }

        /// <summary>
        /// Appends child components to inner html
        /// </summary>
        /// <param name="clearHtml">if true, clears inner html before appending</param>
        protected virtual void AppendChildrenToHtml(bool clearHtml = false)
        {
            if (clearHtml)
                InnerHtml.Clear();
            foreach (var comp in _childComponents)
            {
                InnerHtml.AppendHtml(comp);
            }
        }

        protected virtual void Finish()
        {
        }
    }
}
