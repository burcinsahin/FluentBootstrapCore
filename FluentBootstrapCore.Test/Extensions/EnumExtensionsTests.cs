using FluentBootstrapCore.Enums;
using FluentBootstrapCore.Extensions;

namespace FluentBootstrapCore.Test.Extensions
{
    [TestClass]
    public class EnumExtensionsTests
    {
        public TestContext? TestContext { get; set; }

        [TestMethod]
        public void GetCssDescription_Should()
        {
            var val = 1 << 2;
            WriteLine(val);
            var a = TableStyle.Striped | TableStyle.Bordered;
            WriteLine(a);

            var css = EnumExtensions.GetCssDescription(TableStyle.Striped | TableStyle.Bordered);
            WriteLine(css);
        }

        private void WriteLine(object obj)
        {
            TestContext?.WriteLine(obj.ToString());
        }
    }
}
