﻿using System;
using System.Net.Http;
using System.Threading.Tasks;


namespace MiniBowser
{
    public class HttpHandler : HttpClient
    {

        public async Task<HttpData> RequestResponse(string url)
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
    }

    public class HttpData
    {
        // Instance Variables
        // Auto generated by the properties

        // Accessors
        public string StatusCode
        { get; set; }

        public string HtmlBody
        { get; set; }

        // Constructors
        public HttpData(string statusCode, string htmlBody)
        {
            StatusCode = statusCode;
            HtmlBody = htmlBody;
        }

        public HttpData()
        {
            StatusCode = "No request made";
            HtmlBody = "No body";
        }

        // Methods
        public override string ToString()
        {
            return string.Format("STATUS CODE:\n{0}\nHTML CONTENT:\n{1}", StatusCode, HtmlBody);
        }
    }
}
