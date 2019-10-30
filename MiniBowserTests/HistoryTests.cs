using NUnit.Framework;
using MiniBowser;

namespace MiniBowserTests
{
    [TestFixture]
    public class HistoryTests
    {
        /// <summary>
        /// Test the initialisation of a History object.
        /// </summary>
        [Test]
        public void TestInitialisation()
        {
            // Arrange
            History hist = new History("https://www.google.com/");

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.google.com/"));
        }


        /// <summary>
        /// Test the initialisation using the empty constructor.
        /// </summary>
        [Test]
        public void TestDefaultInitialisation()
        {
            // Arrange
            History hist = new History();

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.google.com/"));
        }
        
        /// <summary>
        /// Test that adding a site to the list works.
        /// </summary>
        [Test]
        public void TestAddSiteToList()
        {
            // Arrange
            History hist = new History();

            // Act
            hist.AddSiteToList("https://www.hw.ac.uk/");

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.hw.ac.uk/"));
            Assert.AreEqual("https://www.hw.ac.uk/", hist.GetLastSite());
        }

        /// <summary>
        /// Test that adding a new site adds it to the url list and the previous
        /// sites stack.
        /// </summary>
        [Test]
        public void TestAddNewSite()
        {
            // Arrange
            History hist = new History();

            // Act
            hist.AddNewSite("https://www.hw.ac.uk/");

            // Assert
            Assert.IsTrue(hist.UrlList.Contains("https://www.hw.ac.uk/"));
            Assert.AreEqual("https://www.hw.ac.uk/", hist.GetLastSite());

            Assert.IsTrue(hist.PreviousSites.Contains("https://www.hw.ac.uk/"));
            Assert.AreEqual("https://www.hw.ac.uk/", hist.PreviousSites.Pop());
        }

        /// <summary>
        /// Test that calling the previous site adds the current site to the
        /// next sites stack and outputs the top of the previous sites stack.
        /// </summary>
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

        }

        /// <summary>
        /// Test that calling the next site adds the current site to the
        /// previous sites stack and outputs the top of the next sites stack.
        /// </summary>
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
