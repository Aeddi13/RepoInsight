using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RepoInsight.BusinessLogic.Test
{
    /// <summary>
    /// Testclass for the <see cref="FileInfoSortHelper"/> class.
    /// </summary>
    [TestClass]
    public class FileInfoSortHelperTest
    {
        [TestMethod]
        public void WhenComparingFileInfosByLeadingSpacesPerLine_AndXisGreaterThanY_ThenItReturnPositiveValue()
        {
            // Arrange
            const int expectedValue = 1;
            // LeadingSpacesPerLine is 1
            FileInfo xValue = new FileInfo() {LinesOfCode = 10, NumberOfLeadingSpaces = 10 }; 
            // LeadingSpacesPerLine is 0.5
            FileInfo YValue = new FileInfo() { LinesOfCode = 20, NumberOfLeadingSpaces = 10 };

            // Act
            int actualValue = FileInfoSortHelper.CompareFileInfosByLeadingSpacesPerLine(xValue, YValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenComparingFileInfosByLeadingSpacesPerLine_AndXisSmallerThanY_ThenItShouldReturnNegativeValue()
        {
            // Arrange
            const int expectedValue = -1;
            // LeadingSpacesPerLine is 1
            FileInfo xValue = new FileInfo() { LinesOfCode = 10, NumberOfLeadingSpaces = 10 };
            // LeadingSpacesPerLine is 2
            FileInfo YValue = new FileInfo() { LinesOfCode = 5, NumberOfLeadingSpaces = 10 };

            // Act
            int actualValue = FileInfoSortHelper.CompareFileInfosByLeadingSpacesPerLine(xValue, YValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenComparingFileInfosByLeadingSpacesPerLine_AndXisEqualToY_ThenItShouldReturn0()
        {
            // Arrange
            const int expectedValue = 0;
            // LeadingSpacesPerLine is 1
            FileInfo xValue = new FileInfo() { LinesOfCode = 10, NumberOfLeadingSpaces = 10 };
            // LeadingSpacesPerLine is 1
            FileInfo YValue = new FileInfo() { LinesOfCode = 10, NumberOfLeadingSpaces = 10 };

            // Act
            int actualValue = FileInfoSortHelper.CompareFileInfosByLeadingSpacesPerLine(xValue, YValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenComparingFileInfosByLinesOfCode_AndXisGreaterThanY_ThenItReturnPositiveValue()
        {
            // Arrange
            const int expectedValue = 1;
            FileInfo xValue = new FileInfo() { LinesOfCode = 20};
            FileInfo YValue = new FileInfo() { LinesOfCode = 10};

            // Act
            int actualValue = FileInfoSortHelper.CompareFileInfosByLinesOfCode(xValue, YValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenComparingFileInfosByLinesOfCode_AndXisSmallerThanY_ThenItShouldReturnNegativeValue()
        {
            // Arrange
            const int expectedValue = -1;
            FileInfo xValue = new FileInfo() { LinesOfCode = 10};
            FileInfo YValue = new FileInfo() { LinesOfCode = 15};

            // Act
            int actualValue = FileInfoSortHelper.CompareFileInfosByLinesOfCode(xValue, YValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenComparingFileInfosByLinesOfCode_AndXisEqualToY_ThenItShouldReturn0()
        {
            // Arrange
            const int expectedValue = 0;
            FileInfo xValue = new FileInfo() { LinesOfCode = 10};
            FileInfo YValue = new FileInfo() { LinesOfCode = 10};

            // Act
            int actualValue = FileInfoSortHelper.CompareFileInfosByLinesOfCode(xValue, YValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
    }
}
