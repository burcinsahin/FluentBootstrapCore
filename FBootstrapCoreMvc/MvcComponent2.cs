namespace FBootstrapCoreMvc
{
    public abstract class MvcComponent2<TModel> : HtmlComponent
    {
        public MvcComponent2(string tagName, params string[] cssClasses)
            : base(tagName, cssClasses)
        {
            AddCss(cssClasses);
        }

        //public TComponent AddCss(string css)
        //{
        //    AddCssClass(css);
        //    return (TComponent)this;
        //}

        //public TComponent SetId(string id)
        //{
        //    MergeAttribute("id", id, true);
        //    return (TComponent)this;
        //}

        //public MvcBuilder<TComponent, TModel> Begin()
        //{
        //    return new MvcBuilder<TComponent, TModel>(Helper, (TComponent)this);
        //}
    }
}
