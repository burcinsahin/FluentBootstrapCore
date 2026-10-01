using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore
{
    internal class MvcComponentStack(IHtmlHelper htmlHelper) : IComponentStack
    {
        private static readonly object _componentStackKey;

        static MvcComponentStack()
        {
            _componentStackKey = new object();
        }

        public IHtmlComponent? Find<T>()
        {
            var item = htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            return item is Stack<IHtmlComponent> stack && stack.Count != 0
                ? stack.FirstOrDefault(item => item.GetType().Equals(typeof(T)))
                : default;
        }

        public IHtmlComponent? Peek()
        {
            var item = htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            return item is Stack<IHtmlComponent> stack && stack.Count != 0 ? stack.Peek() : default;
        }

        public IHtmlComponent? Pop()
        {
            var item = htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            return item is Stack<IHtmlComponent> stack && stack.Count != 0 ? stack.Pop() : default;
        }

        public IReadOnlyList<IHtmlComponent> Snapshot()
        {
            var item = htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            return item is Stack<IHtmlComponent> stack ? stack.ToArray() : [];
        }

        public void Push(IHtmlComponent component)
        {
            if (htmlHelper.ViewContext.HttpContext.Items[_componentStackKey] is not Stack<IHtmlComponent> stack)
            {
                stack = new Stack<IHtmlComponent>();
                htmlHelper.ViewContext.HttpContext.Items[_componentStackKey] = stack;
            }
            stack.Push(component);
        }
    }
}