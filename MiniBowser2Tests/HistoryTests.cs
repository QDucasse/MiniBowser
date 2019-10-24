using NUnit.Framework;
using MiniBowser;

namespace MiniBowserTests
{
    [TestFixture]
    public class HistoryTests
    {
        [Test]
        public void TestInitialisation()
        {
            // Arrange
            History hist = new History("https://www.google.com/");

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.google.com/"));
            Assert.AreEqual("https://www.google.com/", hist.GetCurrentSite());
        }

        [Test]
        public void TestDefaultInitialisation()
        {
            // Arrange
            History hist = new History();

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.google.com/"));
            Assert.AreEqual("https://www.google.com/", hist.GetCurrentSite());
        }

        [Test]
        public void TestAddSiteToQueue()
        {
            // Arrange
            History hist = new History();

            // Act
            hist.AddSiteToList("https://www.hw.ac.uk/");

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.hw.ac.uk/"));
            Assert.AreEqual("https://www.hw.ac.uk/", hist.GetCurrentSite());
        }

        [Test]
        public void TestAddNewSite()
        {
            // Arrange
            History hist = new History();

            // Act
            hist.AddNewSite("https://www.hw.ac.uk/");

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.hw.ac.uk/"));
            Assert.AreEqual("https://www.hw.ac.uk/", hist.GetCurrentSite());

            Assert.IsTrue(hist.PreviousSites.Contains("https://www.hw.ac.uk/"));
            Assert.AreEqual("https://www.hw.ac.uk/", hist.PreviousSites.Pop());
        }

        [Test]
        public void TestPreviousSite()
        {
            // Arrange
            History hist = new History();
            hist.AddNewSite("https://www.hw.ac.uk/");

            // Act
            string previousSite = hist.ReturnPreviousSite("https://www.vision.hw.ac.uk/");

            // Assert
            Assert.AreEqual(previousSite, "https://www.hw.ac.uk/");

            Assert.IsTrue(hist.NextSites.Contains("https://www.vision.hw.ac.uk/"));
            Assert.AreEqual("https://www.vision.hw.ac.uk/", hist.NextSites.Pop());

            Assert.IsTrue(hist.UrlList.Contains("https://www.vision.hw.ac.uk/"));
            Assert.AreEqual("https://www.vision.hw.ac.uk/", hist.GetCurrentSite());
        }

        [Test]
        public void TestNextSite()
        {
            // Arrange
            History hist = new History();
            hist.AddNewSite("https://www.hw.ac.uk/");
            string previousSite = hist.ReturnPreviousSite("https://www.vision.hw.ac.uk/");

            // Act
            string nextSite = hist.ReturnNextSite(previousSite);

            // Assert
            Assert.AreEqual(nextSite, "https://www.vision.hw.ac.uk/");

            Assert.IsTrue(hist.NextSites.Count == 0);

            Assert.IsTrue(hist.PreviousSites.Contains(previousSite));
            Assert.AreEqual(previousSite, hist.PreviousSites.Pop());

            Assert.IsTrue(hist.UrlList.Contains(previousSite));
        }
    }
}
