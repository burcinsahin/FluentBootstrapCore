using FluentBootstrapCore.Components;
using FluentBootstrapCore.Enums;

namespace FluentBootstrapCore.Extensions
{
    public static class ModalExtensions
    {
        public static BootstrapContent<TComponent> Show<TComponent>(
            this BootstrapContent<TComponent> content,
            bool show = true)
            where TComponent : Modal
        {
            content.Component.Show = show;
            return content;
        }

        public static BootstrapContent<TComponent> Fade<TComponent>(
            this BootstrapContent<TComponent> content,
            bool fade = true)
            where TComponent : Modal
        {
            content.Component.Fade = fade;
            return content;
        }

        public static BootstrapContent<TComponent> StaticBackdrop<TComponent>(
            this BootstrapContent<TComponent> content,
            bool staticBackdrop = true) where TComponent : Modal
        {
            content.Component.StaticBackdrop = staticBackdrop;
            return content;
        }

        public static BootstrapContent<TComponent> WithHeader<TComponent>(
            this BootstrapContent<TComponent> content,
            object header) where TComponent : Modal
        {
            content.Component.Header = header;
            return content;
        }

        public static BootstrapContent<TComponent> Scrollable<TComponent>(
            this BootstrapContent<TComponent> content,
            bool scrollable = true) where TComponent : Modal
        {
            content.Component.Scrollable = scrollable;
            return content;
        }

        /// <summary>
        /// Centers modal vertically
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="content"></param>
        /// <param name="vcentered"></param>
        /// <returns></returns>
        public static BootstrapContent<TComponent> Centered<TComponent>(
            this BootstrapContent<TComponent> content,
            bool vcentered = true) where TComponent : Modal
        {
            content.Component.VCentered = vcentered;
            return content;
        }

        /// <summary>
        /// Fullscreen
        /// </summary>
        /// <typeparam name="TComponent"></typeparam>
        /// <param name="content"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static BootstrapContent<TComponent> Full<TComponent>(
            this BootstrapContent<TComponent> content,
            Breakpoint br = Breakpoint.Default) where TComponent : Modal
        {
            content.Component.Fullscreen = br;
            return content;
        }

        public static BootstrapContent<ModalBody> Body(this ComponentBuilder<Modal> builder, object? content = null)
        {
            var modalBody = new ModalBody
            {
                Content = content
            };
            return new BootstrapContent<ModalBody>(builder.HtmlHelper, modalBody);
        }

        public static BootstrapContent<ModalHeader> Header(this ComponentBuilder<Modal> builder, object? content = null)
        {
            var header = new ModalHeader
            {
                Content = content
            };
            return new BootstrapContent<ModalHeader>(builder.HtmlHelper, header);
        }

        public static BootstrapContent<ModalFooter> Footer(this ComponentBuilder<Modal> builder, object? content = null)
        {
            var footer = new ModalFooter
            {
                Content = content
            };
            return new BootstrapContent<ModalFooter>(builder.HtmlHelper, footer);
        }

        public static BootstrapContent<Button> CloseButton(this ComponentBuilder<ModalFooter> builder, object? content = null)
        {
            var button = new Button
            {
                Content = content,
                ButtonState = ButtonState.Secondary
            };
            button.MergeAttribute("data-bs-dismiss", "modal");
            return new BootstrapContent<Button>(builder.HtmlHelper, button);
        }
    }
}
