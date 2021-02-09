using Core;
using Xunit;

namespace Infrastructure.Tests
{
    public class FileBuilderTests
    {
        private readonly IFileBuilder<object> _fileBuilder;

        public FileBuilderTests()
        {
            _fileBuilder = new FileBuilder<object>();
        }

        [Fact]
        public void ToPdf_ReturnsByteArray_GivenHtmlString()
        {
            var htmlContent = "<html><body><p>Foo</p><p>Bar</p></body></html>";

            var actual = _fileBuilder.ToPdf(htmlContent);

            Assert.NotNull(actual);
            Assert.True(actual.Length > 0);
        }
    }
}
