using NUnit.Framework;
using MiniBowser;

namespace MiniBowserTests
{
    [TestFixture()]
    public class MiniBowserTests
    {
        [Test]
        // TODO!!
        public void TestInitialisation()
        {
            // Arrange
            Bookmark bm = new Bookmark("Google", "http://www.google.com");

            // Assert
            Assert.AreEqual("Google", bm.Name);
            Assert.AreEqual("http://www.google.com", bm.Url);
        }
    }
}
