using FBootstrapCoreMvc.Components;
using FBootstrapCoreMvc.Enums;

namespace FBootstrapCoreMvc.Extensions
{
    public static class ModalExtensions
    {
        public static BootstrapContent<Modal> Modal(this IBootstrapHelper bootstrapHelper,
            string? title = null, object? content = null)
        {
            var modal = new Modal
            {
                Title = title,
                Content = content
            };
            return new BootstrapContent<Modal>(bootstrapHelper.HtmlHelper, modal);
        }

        public static BootstrapContent<ModalBody> ModalBody(this BootstrapBuilder<Modal> builder, object? content = null)
        {
            var modalBody = new ModalBody
            {
                Content = content
            };
            return new BootstrapContent<ModalBody>(builder.HtmlHelper, modalBody);
        }

        public static BootstrapContent<ModalHeader> ModalHeader(this BootstrapBuilder<Modal> builder, object? content = null)
        {
            var header = new ModalHeader
            {
                Content = content
            };
            return new BootstrapContent<ModalHeader>(builder.HtmlHelper, header);
        }

        public static BootstrapContent<ModalFooter> ModalFooter(this BootstrapBuilder<Modal> builder, object? content = null)
        {
            var footer = new ModalFooter
            {
                Content = content
            };
            return new BootstrapContent<ModalFooter>(builder.HtmlHelper, footer);
        }
    }
}
