namespace FluentBootstrapCore
{
    internal static class ComponentStackManager
    {
        public static IComponentStack? ComponentStack { get; set; }

        internal static bool Any<T>()
        {
            return (ComponentStack?.Find<T>()) != null;
        }
    }
}