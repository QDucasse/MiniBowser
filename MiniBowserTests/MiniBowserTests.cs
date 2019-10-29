using NUnit.Framework;
using MiniBowser;

namespace MiniBowserTests
{
    [TestFixture()]
    public class MiniBowserTests
    {
        [Test]
        public void TestAddBookmark()
        {
            // Arrange
            Bookmark bm = new Bookmark("Google", "http://www.google.com");
            MiniBowser.MiniBowser mb = new MiniBowser.MiniBowser();

            // Act
            mb.AddBookmark(bm);

            // Assert
            Assert.IsTrue(mb.BookmarkList.Contains(bm));
        }

        [Test]
        public void TestRemoveBookmark()
        {
            // Arrange
            Bookmark bm = new Bookmark("Google", "http://www.google.com");
            MiniBowser.MiniBowser mb = new MiniBowser.MiniBowser();
            mb.AddBookmark(bm);

            // Act
            mb.RemoveBookmark(bm);

            // Assert
            Assert.IsFalse(mb.BookmarkList.Contains(bm));
        }
    }
}
