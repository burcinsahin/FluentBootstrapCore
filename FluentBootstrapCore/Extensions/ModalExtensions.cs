using FluentBootstrapCore.Components;

namespace FluentBootstrapCore.Extensions
{
    public static class ModalExtensions
    {
        public static BootstrapContent<ModalBody> ModalBody(this ComponentBuilder<Modal> builder, object? content = null)
        {
            var modalBody = new ModalBody
            {
                Content = content
            };
            return new BootstrapContent<ModalBody>(builder.HtmlHelper, modalBody);
        }

        public static BootstrapContent<ModalHeader> ModalHeader(this ComponentBuilder<Modal> builder, object? content = null)
        {
            var header = new ModalHeader
            {
                Content = content
            };
            return new BootstrapContent<ModalHeader>(builder.HtmlHelper, header);
        }

        public static BootstrapContent<ModalFooter> ModalFooter(this ComponentBuilder<Modal> builder, object? content = null)
        {
            var footer = new ModalFooter
            {
                Content = content
            };
            return new BootstrapContent<ModalFooter>(builder.HtmlHelper, footer);
        }
    }
}
