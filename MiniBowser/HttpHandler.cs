using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MiniBowser
{
    /// <summary>
    /// Wrapper of the HttpClient class from System.Net.Http to serve our
    /// objectives in the system.
    /// </summary>
    public class HttpHandler : HttpClient
    {
        /// <summary>
        /// Performs a GET HTTP call to the given url and outputs the
        /// HTTP response.
        /// </summary>
        /// <param name="url">URL where the request has to be made</param>
        /// <returns>Task object holding a HttpData object</returns>
        public async Task<HttpData> RequestHTTPResponse(string url)
        {
            HttpData responseData = new HttpData();

            // Call asynchronous network methods in a try/catch block to handle exceptions.
            try
            {
                HttpResponseMessage response = await GetAsync(url);
                // response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                responseData = new HttpData(response.StatusCode.ToString(), responseBody);
                return responseData;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return responseData;

        }

        /// <summary>
        /// Tests if the input string match a correct URL pattern then runs
        /// the RequestHTTPResponse, storing the results in an HttpData object
        /// which string output is the version that should be displayed in the
        /// browser.
        /// </summary>
        /// <param name="url">URL that will be requested</param>
        /// <returns>Either an HttpData.ToString() holding all information
        /// or an "Incorrect URL" string</returns>
        public string RequestStringResult(string url)
        {
            Match m = Regex.Match(url, @"https?:\/\/(www\.)?[-a-zA-Z0-9@:%._\+~#=]{1,256}\.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%_\+.~#?&//=]*)");
            if (m.Success)
            {
                HttpData requestRes = new HttpData();
                Task<HttpData> taskRes = RequestHTTPResponse(url);
                requestRes = taskRes.Result;
                // display html content(tostring)
                return requestRes.ToString();
            }
            else
            {
                return "Incorrect URL";
            }
        }
    }

    /// <summary>
    /// Memory representation of an HTTP response. It only keeps the status code,
    /// HTML content and searches for the title of the page.
    /// </summary>
    public class HttpData
    {
        // Accessors
        // =========

        /// <summary>
        /// Status code of the HTTP response (e.g. "NotFound", "Success", ...)
        /// </summary>
        public string StatusCode
        { get; set; }

        /// <summary>
        /// Title of the page if found.
        /// </summary>
        public string HtmlTitle
        { get; set; }

        /// <summary>
        /// HTML content of the URL.
        /// </summary>
        public string HtmlBody
        { get; set; }

        // Constructors
        // ============

        /// <summary>
        /// Create a HTTP data object from a status code and HTML content strings.
        /// Looks for the title of the page by scrapping the HTML.
        /// </summary>
        /// <param name="statusCode">Status code of the HTTP response</param>
        /// <param name="htmlBody">HTML content of the response</param>
        public HttpData(string statusCode, string htmlBody)
        {
            StatusCode = statusCode;
            HtmlBody = htmlBody;
            Match m = Regex.Match(htmlBody, @"<title>\s*(.+?)\s*</title>");
            if (m.Success)
            {
                HtmlTitle =  m.Groups[1].Value;
            }
            else
            {
                HtmlTitle = "";
            }
        }

        /// <summary>
        /// Default constructor to output an empty response
        /// </summary>
        public HttpData()
        {
            StatusCode = "No request made";
            HtmlBody = "No body";
        }

        // Methods
        // =======

        /// <summary>
        /// Overridden ToString() method to output the actual text to be
        /// displayed consisting of:
        /// Status Code:  this.statusCode
        /// HTML Title:   this.htmlTitle
        /// HTML Content: this.htmlContent
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("STATUS CODE: {0}\n\nHTML TITLE: " +
                "{1}\n\nHTML CONTENT:\n{2}", StatusCode, HtmlTitle, HtmlBody);
        }
    }
}
