using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;

namespace FluentBootstrapCore
{
    internal static class ComponentStackManager
    {
        // Thread-static (not a plain static): the pointer must never be shared between concurrent requests.
        // AsyncLocal is not suitable because IHtmlContent.WriteTo runs when the view buffer is flushed,
        // outside the execution context in which Bootstrap() was called. Every synchronous entry point
        // (Bootstrap(), ComponentBuilder ctor/Dispose, WriteTo) therefore re-establishes it via Use().
        [ThreadStatic]
        private static IComponentStack? _componentStack;

        public static IComponentStack? ComponentStack
        {
            get => _componentStack;
            set => _componentStack = value;
        }

        /// <summary>
        /// Binds the current thread's component stack to the request that owns <paramref name="htmlHelper"/>.
        /// </summary>
        internal static void Use(IHtmlHelper htmlHelper)
        {
            _componentStack = new MvcComponentStack(htmlHelper);
        }

        /// <summary>
        /// Captures the parent chain (top to bottom) of the request that owns <paramref name="htmlHelper"/>.
        /// </summary>
        internal static IReadOnlyList<IHtmlComponent> SnapshotFor(IHtmlHelper htmlHelper)
        {
            return new MvcComponentStack(htmlHelper).Snapshot();
        }

        internal static bool Any<T>()
        {
            return (ComponentStack?.Find<T>()) != null;
        }
    }
}