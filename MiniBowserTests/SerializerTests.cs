using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using MiniBowser;


namespace MiniBowserTests
{
    [TestFixture]
    public class SerializerTests
    {
        Serializer serializer;
        string expectedHistory = "{\"UrlList\":[\"https://www.google.com/\",\"https://www.hw.ac.uk/\",\"https://www.vision.hw.ac.uk/\",\"https://www.outlook.com/\"],\"PreviousSites\":[\"https://www.outlook.com/\",\"https://www.vision.hw.ac.uk/\",\"https://www.hw.ac.uk/\"],\"NextSites\":[]}";
        string expectedBookmarks = "[{\"Name\":\"Google\",\"Url\":\"http://www.google.com/\"},{\"Name\":\"HWU\",\"Url\":\"http://www.hw.ac.uk/\"},{\"Name\":\"Vision\",\"Url\":\"http://www.vision.hw.ac.uk/\"},{\"Name\":\"Mail\",\"Url\":\"http://www.outlook.com/\"}]";

        /// <summary>
        /// Deletes the existing json files.
        /// </summary>
        [SetUp]
        public void TestInitialize()
        {
            File.Delete(Serializer.pathHistory);
            File.Delete(Serializer.pathBookmarks);
            File.Delete(Serializer.pathHomepage);
            serializer = new Serializer();
        }

        /// <summary>
        /// Test the serialization of a history object.
        /// </summary>
        [Test]
        public void TestSerializeAndStoreHistory()
        {
            // Arrange
            History hist = new History();
            hist.AddNewSite("https://www.hw.ac.uk/");
            hist.AddNewSite("https://www.vision.hw.ac.uk/");
            hist.AddNewSite("https://www.outlook.com/");

            // Act
            serializer.SerializeAndStoreHistory(hist);
            string actual = System.IO.File.ReadAllText(Serializer.pathHistory);

            // Assert
            Assert.AreEqual(expectedHistory, actual);
        }

        /// <summary>
        /// Test the serialization of a list of bookamrks.
        /// </summary>
        [Test]
        public void TestSerializeAndStoreBookmarks()
        {
            // Arrange
            Bookmark bm1 = new Bookmark("Google", "http://www.google.com/");
            Bookmark bm2 = new Bookmark("HWU", "http://www.hw.ac.uk/");
            Bookmark bm3 = new Bookmark("Vision", "http://www.vision.hw.ac.uk/");
            Bookmark bm4 = new Bookmark("Mail", "http://www.outlook.com/");
            List<Bookmark> bmList = new List<Bookmark>() { bm1, bm2, bm3, bm4 };

            // Act
            serializer.SerializeAndStoreBookmarks(bmList);
            string actual = File.ReadAllText(Serializer.pathBookmarks);

            // Assert
            Assert.AreEqual(expectedBookmarks, actual);
        }

        /// <summary>
        /// Test the serialization of a homepage.
        /// </summary>
        [Test]
        public void TestSerializeAndStoreHomePage()
        {
            // Arrange
            string homePage = "https://www.google.com/";

            // Act
            serializer.SerializeAndStoreHomePage(homePage);

            // Assert
            Assert.AreEqual("\"https://www.google.com/\"", File.ReadAllText(Serializer.pathHomepage));
        }

        /// <summary>
        /// Test the serialization of a browser object.
        /// </summary>
        [Test]
        public void TestSerializeAndStoreBrowser()
        {
            // Arrange
            MiniBowser.MiniBowser mb = new MiniBowser.MiniBowser();
            // History
            mb.History.AddNewSite("https://www.hw.ac.uk/");
            mb.History.AddNewSite("https://www.vision.hw.ac.uk/");
            mb.History.AddNewSite("https://www.outlook.com/");

            // Bookmarks
            Bookmark bm1 = new Bookmark("Google", "http://www.google.com/");
            Bookmark bm2 = new Bookmark("HWU", "http://www.hw.ac.uk/");
            Bookmark bm3 = new Bookmark("Vision", "http://www.vision.hw.ac.uk/");
            Bookmark bm4 = new Bookmark("Mail", "http://www.outlook.com/");
            mb.AddBookmark(bm1);
            mb.AddBookmark(bm2);
            mb.AddBookmark(bm3);
            mb.AddBookmark(bm4);

            // homepage
            mb.Homepage = "https://www.google.com/";

            // Act
            serializer.SerializeAndStoreBrowser(mb);
            string actualHistory = File.ReadAllText(Serializer.pathHistory);
            string actualBookmarks = File.ReadAllText(Serializer.pathBookmarks);


            // Assert
            Assert.AreEqual(expectedBookmarks, actualBookmarks);
            Assert.AreEqual(expectedHistory, actualHistory);
            Assert.AreEqual("\"https://www.google.com/\"", System.IO.File.ReadAllText(Serializer.pathHomepage));
        }
    }
}
