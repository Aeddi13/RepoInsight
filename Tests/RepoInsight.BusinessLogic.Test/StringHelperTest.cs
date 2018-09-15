using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ComplexCity.BusinessLogic.Test
{
    /// <summary>
    /// Testclass for the <see cref="StringHelper"/> class.
    /// </summary>
    [TestClass]
    public class StringHelperTest
    {
        #region IsLineAComment
        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithDoubleSlash_ThenItShouldReturnTrue()
        {
            // Arrange
            const bool expectedValue = true;
            const string testValue = "   //this is a comment\\n";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithNumberSign_ThenItShouldReturnTrue()
        {
            // Arrange
            const bool expectedValue = true;
            const string testValue = "   #this is a comment\\n";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithSlashStar_ThenItShouldReturnTrue()
        {
            // Arrange
            const bool expectedValue = true;
            const string testValue = "   /*this is a comment\\n";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithStarWhitespace_ThenItShouldReturnTrue()
        {
            // Arrange
            const bool expectedValue = true;
            const string testValue = "   * this is a comment\\n";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithLessThanExclamationMarkMinusMinus_ThenItShouldReturnTrue()
        {
            // Arrange
            const bool expectedValue = true;
            const string testValue = "   <!-- this is a comment\\n";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithStarWithNoFollowingWhitespace_ThenItShouldReturnFalse()
        {
            // Arrange
            const bool expectedValue = false;
            const string testValue = "   *thisIsNoComment";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithLetter_ThenItShouldReturnFalse()
        {
            // Arrange
            const bool expectedValue = false;
            const string testValue = "   No Comment";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineStartsWithNumber_ThenItShouldReturnFalse()
        {
            // Arrange
            const bool expectedValue = false;
            const string testValue = "  10 No Comment";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineIsNull_ThenItShouldReturnFalse()
        {
            // Arrange
            const bool expectedValue = false;
            const string testValue = null;

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineIsEmptyString_ThenItShouldReturnFalse()
        {
            // Arrange
            const bool expectedValue = false;
            string testValue = String.Empty;

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }

        [TestMethod]
        public void WhenCheckingIsLineAComment_AndLineIsOnlyWhitespacesAndTabs_ThenItShouldReturnFalse()
        {
            // Arrange
            const bool expectedValue = false;
            const string testValue = "            ";

            // Act
            bool actualValue = StringHelper.IsLineAComment(testValue);

            // Assert
            Assert.AreEqual(expectedValue, actualValue);
        }
        #endregion IsLineAComment
    }
}
