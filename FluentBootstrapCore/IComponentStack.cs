using System.Collections.Generic;

namespace FluentBootstrapCore
{
    internal interface IComponentStack
    {
        void Push(IHtmlComponent component);
        IHtmlComponent? Pop();
        IHtmlComponent? Peek();
        IHtmlComponent? Find<T>();

        /// <summary>
        /// Returns the current stack contents ordered from top to bottom.
        /// </summary>
        IReadOnlyList<IHtmlComponent> Snapshot();
    }
}
