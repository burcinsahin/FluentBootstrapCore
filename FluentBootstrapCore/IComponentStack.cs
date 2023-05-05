namespace FluentBootstrapCore
{
    internal interface IComponentStack
    {
        void Push(IHtmlComponent component);
        IHtmlComponent? Pop();
        IHtmlComponent? Peek();
    }
}
