using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace FBootstrapCoreMvc
{
    [Obsolete("Use HtmlComponent instead.")]
    public abstract class Component<TComponent> : Component
        where TComponent : Component<TComponent>
    {
        protected readonly IHtmlHelper _helper;

        public Component(IHtmlHelper helper, string tagName, params string[] cssClasses)
            : base(helper, tagName, cssClasses)
        {
            _helper = helper;
        }

        public HtmlBuilder<TComponent> Begin()
        {
            return new HtmlBuilder<TComponent>(_helper, (TComponent)this);
        }

        public TComponent AddAttribute(string key, object? value = null)
        {
            if (value != null)
                MergeAttribute(key, value.ToString(), true);
            else
                MergeAttribute(key, null, true);
            return (TComponent)this;
        }

        protected internal TComponent AddCss(params string[] cssClasses)
        {
            foreach (var css in cssClasses)
            {
                AddCssClass(css);
            }
            return (TComponent)this;
        }
    }
}
