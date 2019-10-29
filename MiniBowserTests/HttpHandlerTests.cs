using System.Threading.Tasks;
using NUnit.Framework;
using MiniBowser;

namespace MiniBowserTests
{
    [TestFixture]
    public class HttpHandlerTests
    {
        [Test]
        public void TestStatusCode200()
        {
            // Arrange
            HttpData requestRes = new HttpData();
            HttpHandler httpHandler = new HttpHandler();

            // Act
            Task<HttpData> taskRes = httpHandler.RequestHTTPResponse("http://httpstat.us/200");
            requestRes = taskRes.Result;

            // Assert
            Assert.AreEqual(requestRes.StatusCode, "OK");
        }

        [Test]
        public void TestStatusCode400()
        {
            // Arrange
            HttpData requestRes = new HttpData();
            HttpHandler httpHandler = new HttpHandler();

            // Act
            Task<HttpData> taskRes = httpHandler.RequestHTTPResponse("http://httpstat.us/400");
            requestRes = taskRes.Result;

            // Assert
            Assert.AreEqual(requestRes.StatusCode, "BadRequest");
        }

        [Test]
        public void TestStatusCode403()
        {
            // Arrange
            HttpData requestRes = new HttpData();
            HttpHandler httpHandler = new HttpHandler();

            // Act
            Task<HttpData> taskRes = httpHandler.RequestHTTPResponse("http://httpstat.us/403");
            requestRes = taskRes.Result;

            // Assert
            Assert.AreEqual(requestRes.StatusCode, "Forbidden");
        }

        [Test]
        public void TestStatusCode404()
        {
            // Arrange
            HttpData requestRes = new HttpData();
            HttpHandler httpHandler = new HttpHandler();

            // Act
            Task<HttpData> taskRes = httpHandler.RequestHTTPResponse("http://httpstat.us/404");
            requestRes = taskRes.Result;

            // Assert
            Assert.AreEqual(requestRes.StatusCode, "NotFound");
        }

        [Test]
        public void TestRequestIncorrectUrl()
        {
            // Arrange
            HttpHandler httpHandler = new HttpHandler();
            string url = "http://http";

            // Act
            string res = httpHandler.RequestStringResult(url);

            // Assert
            Assert.AreEqual(res, "Incorrect URL");
        }
    }

    [TestFixture]
    public class HttpDataTests
    {
        [Test]
        public void TestInitialisation()
        {
            // Arrange
            HttpData httpData = new HttpData();

            // Assert
            Assert.AreEqual("No request made", httpData.StatusCode);
            Assert.AreEqual("No body", httpData.HtmlBody);
        }

        [Test]
        public void TestToString()
        {
            // Arrange
            HttpData httpData = new HttpData("200", "<h1>Hello</h1>");
            string expected = "STATUS CODE: 200\n\nHTML TITLE: \n\nHTML CONTENT:\n<h1>Hello</h1>";
            // Act
            string result = httpData.ToString();

            // Assert
            Assert.AreEqual(result, expected);
        }
    }
}
