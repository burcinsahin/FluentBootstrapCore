﻿namespace FBootstrapCoreMvc.Components
{
    public class PageItem : BootstrapComponent
    {
        private Link _link;

        public PageItem()
            : base("li", Css.PageItem)
        {
            _link = new Link();
            _link.AddCss(Css.PageLink);
        }

        protected override void PreBuild()
        {
            AddChild(_link);
            base.PreBuild();
        }

        protected internal PageItem SetLink(string? href, object? content)
        {
            _link.Href = href;
            _link.Content = content;
            return this;
        }

        public PageItem SetActive(bool active = true)
        {
            if (active)
                AddCss(Css.Active);

            return this;
        }

        public PageItem SetDisabled(bool disabled = true)
        {
            if (disabled)
                AddCss(Css.Disabled);

            return this;
        }
    }
}