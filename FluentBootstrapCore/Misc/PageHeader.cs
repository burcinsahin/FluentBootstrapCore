using FluentBootstrapCore.Html;
using FluentBootstrapCore.Typography;
using System.IO;

namespace FluentBootstrapCore.Misc
{
    public class PageHeader : Heading, IHasTextContent
    {
        private Element _wrapper;

        internal PageHeader(BootstrapHelper helper)
            : base(helper, "h1")
        {
        }

        protected override void OnStart(TextWriter writer)
        {
            _wrapper = GetHelper().Element("div")/*.AddCss(Css.PageHeader)*/.Component;
            _wrapper.Start(writer);
            base.OnStart(writer);
        }

        protected override void OnFinish(TextWriter writer)
        {
            base.OnFinish(writer);
            _wrapper.Finish(writer);
        }
    }
}
