﻿using System.Collections.Generic;

namespace MiniBowser
{
    /// <summary> Class <c> History </c> models a web history
    /// and its behaviour.
    /// </summary>
    public class History
    {
        // Class Variables
        /// <summary>
        /// Max size of the previous and next sites stacks.
        /// </summary>
        private static int StackSize = 20;

        /// <summary>
        /// Max size of the URL list.
        /// </summary>
        private static int ListSize = 20;

        // Accessors & Instance Variables generated by the properties:
        /// <summary>
        /// URL list of the history containing all previously visited sites.
        /// </summary>
        public List<string> UrlList
        { get; set; }

        /// <summary>
        /// Previous sites stack used for the "Previous" action.
        /// </summary>
        public Stack<string> PreviousSites
        { get; set; }

        /// <summary>
        /// Next sites stack used for the "Next" action.
        /// </summary>
        public Stack<string> NextSites
        { get; set; }

        // Constructors
        /// <summary>
        /// Constructor for the <c>History</c> class.
        /// </summary>
        /// <param name="homePageUrl">The homepage of the history</param>
        public History(string homePageUrl)
        {
            UrlList = new List<string>(ListSize);
            UrlList.Add(homePageUrl);
            PreviousSites = new Stack<string>(StackSize);
            NextSites = new Stack<string>(StackSize);
        }

        /// <summary>
        /// Default constructor for the <c>History</c> class using
        /// "https://www.google.com/" as default homepage.
        /// </summary>
        public History()
        {
            UrlList = new List<string>(ListSize);
            UrlList.Add("https://www.google.com/");
            PreviousSites = new Stack<string>(StackSize);
            NextSites = new Stack<string>(StackSize);
        }

        // Methods
        /// <summary>
        /// Add a site to the URL list and checks for the maximum size.
        /// </summary>
        /// <param name="url">Site to be added</param>
        public void AddSiteToList(string url)
        {
            if (UrlList.Count >= ListSize)
            {
                UrlList.RemoveAt(0);
            }

            UrlList.Add(url);
        }

        /// <summary>
        /// Add a site to the URL list as well as the previous sites stack.
        /// </summary>
        /// <param name="url">Site to be added</param>
        public void AddNewSite(string url)
        {
            AddSiteToList(url);
            PreviousSites.Push(url);
        }

        /// <summary>
        /// Return the last visited site.
        /// </summary>
        /// <returns>Last site</returns>
        public string GetLastSite()
        {
            return UrlList[UrlList.Count - 1];
        }

        /// <summary>
        /// Returns the previous site and adds the current site to the
        /// next sites stack.
        /// </summary>
        /// <param name="currentSite">The current site of the browser</param>
        /// <returns>Previously visited site</returns>
        public string ReturnPreviousSite(string currentSite)
        {
            string previousSite = PreviousSites.Pop();
            NextSites.Push(currentSite);
            return previousSite;
        }

        /// <summary>
        /// Returns the next site and adds the current site to the
        /// previous sites stack.
        /// </summary>
        /// <param name="currentSite">The current site of the browser</param>
        /// <returns>Last visited site before pressing "Previous"</returns>
        public string ReturnNextSite(string currentSite)
        {
            string nextSite = NextSites.Pop();
            PreviousSites.Push(currentSite);
            return nextSite;
        }
    }
}
