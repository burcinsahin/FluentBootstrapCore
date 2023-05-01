using FluentBootstrapCore.Interfaces;

namespace FluentBootstrapCore.Components
{
    public class Accordion : BootstrapComponent,
        ICanCreate<AccordionItem>
    {
        public bool Flush { get; set; }
        public bool AlwaysOpen { get; set; }

        public Accordion()
            : base("div", Css.Accordion)
        {
        }

        protected override void PreBuild()
        {
            if (Flush)
                AddCss(Css.AccordionFlush);
            if (Id == null)
                GenerateId();
            base.PreBuild();
        }
    }
}
