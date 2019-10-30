namespace MiniBowser
{
    /// <summary>
    /// Bookmark object holding the information of a Bookmark in memory,
    /// URL and its associated name.
    /// </summary>
    public class Bookmark
    {
        // Accessors
        /// <summary>
        /// The name of the bookmark
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// The URL of the bookmark
        /// </summary>
        public string Url
        { get; set; }

        // Constructor
        /// <summary>
        /// Creates a bookmark from the name and URL
        /// </summary>
        /// <param name="name">Name of the bookmark</param>
        /// <param name="url">URL of the bookmark</param>
        public Bookmark(string name, string url)
        {
            Name = name;
            Url = url;
        }
    }
}
