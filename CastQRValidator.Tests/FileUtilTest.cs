using CastQRValidator.Models;
using CastQRValidator.Utils;
using System.Collections.ObjectModel;
using Xunit;

namespace CastQRValidator.Tests
{
    public class FileUtilTest
    {
        [Fact]
        public void ReadMainframeSamples_Returns()
        {
            // Arrange
            var firstExpectedModel = new Sample("", "", 9990, new Collection<Violation>());

            // Act
            List<Sample>? samples = FileUtil.ReadJsonFromFile<List<Sample>>("mainframe_samples.json");
            
            // Assert
            Assert.NotNull(samples);
        }
    }
}