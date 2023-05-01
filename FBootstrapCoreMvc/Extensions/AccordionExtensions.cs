using FluentBootstrapCore.Components;

namespace FluentBootstrapCore.Extensions
{
    public static class AccordionExtensions
    {
        public static BootstrapContent<AccordionItem> AccordionItem(this BootstrapBuilder<Accordion> builder, string? header = null)
        {
            var accordion = builder.Component;
            var accordionItem = new AccordionItem()
            {
                Header = header,
            };
            if (!accordion.AlwaysOpen)
                accordionItem.ParentId = accordion.Id;
            return new BootstrapContent<AccordionItem>(builder.HtmlHelper, accordionItem);
        }

        public static BootstrapContent<Accordion> Flush(this BootstrapContent<Accordion> content)
        {
            content.Component.Flush = true;
            return content;
        }

        public static BootstrapContent<Accordion> AlwaysOpen(this BootstrapContent<Accordion> content)
        {
            content.Component.AlwaysOpen = true;
            return content;
        }

        public static BootstrapContent<AccordionItem> Show(this BootstrapContent<AccordionItem> content)
        {
            content.Component.Show = true;
            return content;
        }
    }
}
