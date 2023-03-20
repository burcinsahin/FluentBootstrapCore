namespace FBootstrapCoreMvc.Extensions.Tests
{
    [TestClass()]
    public class NumericExtensionsTests
    {
        [TestMethod()]
        public void Trim_Should()
        {
            ((byte)6).Trim((byte)0, (byte)5).Should().Be(5);
            ((byte)3).Trim((byte)0, (byte)5).Should().Be(3);
            ((sbyte)-1).Trim((sbyte)0, (sbyte)5).Should().Be(0);
            12.Trim(0,6).Should().Be(6);
        }
    }
}