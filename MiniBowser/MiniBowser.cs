using System;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MiniBowser
{
    public class MiniBowser
    {
        /// <summary>
        /// Http handler variable limited to readonly.
        /// </summary>
        public readonly HttpHandler httpHandler = new HttpHandler();

        // Accessors
        /// <summary>
        /// Current site displayed by the web browser.
        /// </summary>
        public string CurrentSite
        { get; set; }

        /// <summary>
        /// Homepage of the web browser.
        /// </summary>
        public string Homepage
        { get; set; }

        /// <summary>
        /// List of all the bookmarks of the web browser.
        /// </summary>
        public List<Bookmark> BookmarkList
        { get; set; }

        /// <summary>
        /// History of the web browser.
        /// </summary>
        public History History
        { get; private set; }

        /// <summary>
        /// Serializer of the web browser. 
        /// </summary>
        public Serializer Serializer
        { get; private set; }


        // Constructor
        // ===========

        /// <summary>
        /// Default constructor loading history, bookmarks list and homepage
        /// from the json files if they exist and creating the objects if not.
        /// </summary>
        public MiniBowser()
        {
            Serializer = new Serializer();
            // Load history if existing
            if (File.Exists(Serializer.pathHistory))
            {
                History = Serializer.DeserializeAndLoadHistory();
            }
            else
            {
                History = new History();
            }
            // Load bookmarks if existing
            if (File.Exists(Serializer.pathBookmarks))
            {
                BookmarkList = Serializer.DeserializeAndLoadBookmarks();
            }
            else
            {
                BookmarkList = new List<Bookmark>() ;
            }

            // Load Homepage if existing
            if (File.Exists(Serializer.pathHomepage))
            {
                Homepage = Serializer.DeserializeAndLoadHomepage();
            }
            else
            {
                Homepage = "https://www.google.com/";
            }
        }

        // Methods
        // =======

        /// <summary>
        /// Add a bookmark to the bookmarks list. Used to lighten the methods
        /// using such an operation.
        /// </summary>
        /// <param name="newBookmark">Bookmark to be added></param>
        public void AddBookmark(Bookmark newBookmark)
        {
            BookmarkList.Add(newBookmark);
        }

        /// <summary>
        /// Remove a bookmark from the bookmarks list. Used to lighten the
        /// methods using such an operation.
        /// </summary>
        /// <param name="bookmark">Bookmark to be removed</param>
        public void RemoveBookmark(Bookmark bookmark)
        {
            if (BookmarkList.Contains(bookmark))
            {
                BookmarkList.Remove(bookmark);
            }
        }

        /// <summary>
        /// Serializes history, homepage and bookmarks in json files using
        /// the serializer. Used to lighten the syntax.
        /// </summary>
        public void Store()
        {
            Serializer.SerializeAndStoreBrowser(this);
        }

        /// <summary>
        /// Request the string to be displayed after an HTTP request.
        /// Used to lighten the syntax.
        /// </summary>
        public string RequestResult(string url)
        {
            return httpHandler.RequestStringResult(url);
        }
    }
}
