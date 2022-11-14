using FluentBootstrapCore.Html;
using System.IO;

namespace FluentBootstrapCore.Pagers
{
    public class Pager : Tag,
        ICanCreate<Page>
    {
        private Element _nav = null;

        internal Pager(BootstrapHelper helper)
            : base(helper, "ul"/*, Css.Pager*/)
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _nav = GetHelper().Element("nav").Component;
            _nav.Start(writer);

            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);

            _nav.Finish(writer);
        }
    }
}
