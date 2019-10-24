using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace MiniBowser
{
    public class Serializer
    {
        // Paths to the files
        private static string _basePath = AppDomain.CurrentDomain.BaseDirectory + @"../../../../";
        public static string pathHistory = _basePath + @"history.json";
        public static string pathBookmarks = _basePath + @"bookmarks.json";
        public static string pathHomepage = _basePath + @"homepage.json";

        // Serialize methods

        public void SerializeAndStore<T>(Object obj, string path)
        {
            string json = JsonConvert.SerializeObject(obj);
            File.WriteAllText(path, json);

        }

        public void SerializeAndStoreHistory(History history)
        {
            SerializeAndStore<History>(history, pathHistory);
        }

        public void SerializeAndStoreBookmarks(List<Bookmark> bookmarksList)
        {
            SerializeAndStore<List<Bookmark>>(bookmarksList, pathBookmarks);
        }

        public void SerializeAndStoreHomePage(string homePageUrl)
        {
            SerializeAndStore<Bookmark>(homePageUrl, pathHomepage);
        }

        public void SerializeAndStoreBrowser(MiniBowser miniBowser)
        {
            SerializeAndStoreHistory(miniBowser.History);
            SerializeAndStoreBookmarks(miniBowser.BookmarkList);
            SerializeAndStoreHomePage(miniBowser.Homepage);
        }

        // Deserialize methods

        public History DeserializeAndLoadHistory()
        {
            string json = File.ReadAllText(pathHistory);
            History history = JsonConvert.DeserializeObject<History>(json);
            return history;
        }

        public List<Bookmark> DeserializeAndLoadBookmarks()
        {
            string json = File.ReadAllText(pathBookmarks);
            List<Bookmark> bookmarksList = JsonConvert.DeserializeObject<List<Bookmark>>(json);
            return bookmarksList;
        }

        public string DeserializeAndLoadHomepage()
        {
            string json = File.ReadAllText(pathHomepage);
            string homePage = JsonConvert.DeserializeObject<string>(json);
            return homePage;
        }
    }
}
