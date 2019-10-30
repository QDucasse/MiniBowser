using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MiniBowser
{
    /// <summary>
    /// Serializer allowing the serialization of the different objects
    /// of the system in JSON files. 
    /// </summary>
    public class Serializer
    {
        // Paths to the files
        // ==================

        /// <summary>
        /// Path to the project MiniBowserData where the JSON files are stored.
        /// </summary>
        private static string _basePath = AppDomain.CurrentDomain.BaseDirectory + @"../../../MiniBowserData/";
        /// <summary>
        /// Suffix for the history.json file.
        /// </summary>
        public static string pathHistory = _basePath + @"history.json";
        /// <summary>
        /// Suffix for the bookmarks.json file.
        /// </summary>
        public static string pathBookmarks = _basePath + @"bookmarks.json";
        /// <summary>
        /// Suffix for the homepage.json file.
        /// </summary>
        public static string pathHomepage = _basePath + @"homepage.json";

        // Serialize methods
        // =================

        /// <summary>
        /// Wrapper of the NewtonSsoft.JSONConvert method to serialize an object
        /// and store it to the given path.
        /// </summary>
        /// <typeparam name="T">Type of the object to be serialized</typeparam>
        /// <param name="obj">Object to be serialized</param>
        /// <param name="path">Path of the json file</param>
        public void SerializeAndStore<T>(Object obj, string path)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Serializes a History object using SerializeAndStore method.
        /// </summary>
        /// <param name="history">History to be serialized</param>
        public void SerializeAndStoreHistory(History history)
        {
            SerializeAndStore<History>(history, pathHistory);
        }

        /// <summary>
        /// Serializes a list of bookmarks using SerializeAndStore method.
        /// </summary>
        /// <param name="bookmarksList">List of bookmarks to be serialized</param>
        public void SerializeAndStoreBookmarks(List<Bookmark> bookmarksList)
        {
            SerializeAndStore<List<Bookmark>>(bookmarksList, pathBookmarks);
        }

        /// <summary>
        /// Serializes a homepage using SerializeAndStore method.
        /// </summary>
        /// <param name="homePageUrl">Homepage URL to be serialized</param>
        public void SerializeAndStoreHomePage(string homePageUrl)
        {
            SerializeAndStore<Bookmark>(homePageUrl, pathHomepage);
        }

        /// <summary>
        /// Serializes the full browser by calling the serialization methods
        /// of history, bookmarks list and homepage.
        /// </summary>
        /// <param name="miniBowser">Browser to be serialized</param>
        public void SerializeAndStoreBrowser(MiniBowser miniBowser)
        {
            SerializeAndStoreHistory(miniBowser.History);
            SerializeAndStoreBookmarks(miniBowser.BookmarkList);
            SerializeAndStoreHomePage(miniBowser.Homepage);
        }

        // Deserialize methods
        // ===================

        /// <summary>
        /// Deserialize a History from json file.
        /// </summary>
        /// <returns>History object deserialized</returns>
        public History DeserializeAndLoadHistory()
        {
            string json = File.ReadAllText(pathHistory);
            History history = JsonConvert.DeserializeObject<History>(json);
            return history;
        }

        /// <summary>
        /// Deserialize a list of bookmarks from json file.
        /// </summary>
        /// <returns>List of bookmarks objects deserialized</returns>
        public List<Bookmark> DeserializeAndLoadBookmarks()
        {
            string json = File.ReadAllText(pathBookmarks);
            List<Bookmark> bookmarksList = JsonConvert.DeserializeObject<List<Bookmark>>(json);
            return bookmarksList;
        }

        /// <summary>
        /// Deserialize a homepage from json file.
        /// </summary>
        /// <returns>Homepage string deserialized</returns>
        public string DeserializeAndLoadHomepage()
        {
            string json = File.ReadAllText(pathHomepage);
            string homePage = JsonConvert.DeserializeObject<string>(json);
            return homePage;
        }
    }
}
