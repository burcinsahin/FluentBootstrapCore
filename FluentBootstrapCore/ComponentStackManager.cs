namespace FluentBootstrapCore
{
    internal class ComponentStackManager
    {
        private static IComponentStack? _component;
        public static IComponentStack? ComponentStack
        {
            get { return _component; }
            set { _component = value; }
        }
    }
}