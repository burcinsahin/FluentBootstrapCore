using Microsoft.AspNetCore.Mvc.Testing;
using System.Text.RegularExpressions;

namespace FluentBootstrapCore.Test.Rendering
{
    /// <summary>
    /// Renders Views/Home/UnitTest.cshtml through the real MVC pipeline and checks that
    /// scoped usage (Begin()/Dispose) and direct usage (@Html.Bootstrap().Input()) produce the same HTML.
    /// </summary>
    [TestClass]
    public partial class UnitTestViewRenderingTests
    {
        private const string _viewUrl = "/Tests/UnitTest";
        private static readonly Regex _divFormBlock = HtmlRegex();

        private static WebApplicationFactory<Program> _factory = null!;

        public TestContext? TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _factory = new WebApplicationFactory<Program>();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _factory.Dispose();
        }

        [TestMethod]
        public async Task ScopedAndDirectUsage_Should_RenderIdenticalHtml()
        {
            var html = await GetHtmlAsync();
            TestContext?.WriteLine(html);

            var blocks = ExtractBlocks(html);

            blocks.Should().HaveCount(2);
            blocks[0].Should().Contain("form-control", "Input inside a Form must get the form-control class");
            blocks[1].Should().Be(blocks[0]);
        }

        [TestMethod]
        public async Task ScopedAndDirectUsage_Should_RenderIdenticalHtml_UnderConcurrentRequests()
        {
            var results = await Task.WhenAll(Enumerable.Range(0, 50).Select(async _ =>
            {
                await Task.Yield();
                return ExtractBlocks(await GetHtmlAsync());
            }));

            foreach (var blocks in results)
            {
                blocks.Should().HaveCount(2);
                blocks[0].Should().Contain("form-control");
                blocks[1].Should().Be(blocks[0]);
            }
        }

        private static async Task<string> GetHtmlAsync()
        {
            using var client = _factory.CreateClient();
            using var response = await client.GetAsync(_viewUrl);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        private static List<string> ExtractBlocks(string html)
        {
            return [.. _divFormBlock.Matches(html).Select(m => m.Groups[1].Value)];
        }

        [GeneratedRegex(@"<div><form>(.*?)</form></div>", RegexOptions.Singleline)]
        private static partial Regex HtmlRegex();
    }
}
