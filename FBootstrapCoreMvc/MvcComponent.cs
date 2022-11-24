using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc
{
    [Obsolete("Use HtmlComponent instead.")]
    public abstract class MvcComponent<TComponent, TModel> : Component
        where TComponent : MvcComponent<TComponent, TModel>
    {
        private readonly IHtmlHelper<TModel> _helper;
        protected internal IHtmlHelper<TModel> Helper => _helper;

        public MvcComponent(IHtmlHelper<TModel> helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
            _helper = helper;

            foreach (var cssClass in cssClasses)
            {
                AddCssClass(cssClass);
            }
        }

        public TComponent AddCss(string css)
        {
            AddCssClass(css);
            return (TComponent)this;
        }

        public TComponent SetId(string id)
        {
            MergeAttribute("id", id, true);
            return (TComponent)this;
        }

        public MvcBuilder<TComponent, TModel> Begin()
        {
            return new MvcBuilder<TComponent, TModel>(Helper, (TComponent)this);
        }
    }
}
