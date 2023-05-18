using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace FluentBootstrapCore
{
    internal class MvcComponentStack : IComponentStack
    {
        private static readonly object _componentStackKey;
        private readonly IHtmlHelper _htmlHelper;

        static MvcComponentStack()
        {
            _componentStackKey = new object();
        }

        public MvcComponentStack(IHtmlHelper htmlHelper)
        {
            _htmlHelper = htmlHelper;
        }

        public IHtmlComponent? Find<T>()
        {
            var item = _htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            if (item is Stack<IHtmlComponent> stack && stack.Any())
                return stack.FirstOrDefault(item => item.GetType().Equals(typeof(T)));
            return default;
        }

        public IHtmlComponent? Peek()
        {
            var item = _htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            if (item is Stack<IHtmlComponent> stack && stack.Any())
                return stack.Peek();
            return default;
        }

        public IHtmlComponent? Pop()
        {
            var item = _htmlHelper.ViewContext.HttpContext.Items[_componentStackKey];
            if (item is Stack<IHtmlComponent> stack && stack.Any())
                return stack.Pop();
            return default;
        }

        public void Push(IHtmlComponent component)
        {
            if (!(_htmlHelper.ViewContext.HttpContext.Items[_componentStackKey] is Stack<IHtmlComponent> stack))
            {
                stack = new Stack<IHtmlComponent>();
                _htmlHelper.ViewContext.HttpContext.Items[_componentStackKey] = stack;
            }
            stack.Push(component);
        }
    }
}