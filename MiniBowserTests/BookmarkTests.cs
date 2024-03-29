﻿using NUnit.Framework;
using MiniBowser;

namespace MiniBowserTests
{
    [TestFixture]
    public class BookmarkTests
    {
        /// <summary>
        /// Tests the initialisation of a Bookmark object.
        /// </summary>
        [Test]
        public void TestInitialisation()
        {
            // Arrange
            Bookmark bm = new Bookmark("Google", "http://www.google.com/");

            // Assert
            Assert.AreEqual(bm.Name, "Google");
            Assert.AreEqual(bm.Url, "http://www.google.com/");
        }
    }
}

