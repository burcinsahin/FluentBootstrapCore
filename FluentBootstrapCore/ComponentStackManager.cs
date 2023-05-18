using System.Linq;
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

        internal static bool Any<T>()
        {
            return (ComponentStack?.Find<T>()) != null;
        }
    }
}