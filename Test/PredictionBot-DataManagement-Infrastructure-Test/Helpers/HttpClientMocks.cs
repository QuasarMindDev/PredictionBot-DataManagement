using Moq;
using Moq.Protected;
using System.Net;
using System.Text.Json;

namespace PredictionBot_DataManagement_Infrastructure_Test.Helpers
{
    public static class HttpClientMocks
    {
        public static IHttpClientFactory CreateFactoryMock<T>(T response, HttpStatusCode statusCode)
        {
            var mockFactory = new Mock<IHttpClientFactory>();
            var mockMessageHandler = new Mock<HttpMessageHandler>();

            mockMessageHandler.Protected()
           .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
           .ReturnsAsync(new HttpResponseMessage
           {
               StatusCode = statusCode,
               Content = new StringContent(JsonSerializer.Serialize(response))
           });

            var httpClient = new HttpClient(mockMessageHandler.Object);
            mockFactory.Setup(_ => _.CreateClient(It.IsAny<string>())).Returns(httpClient);

            return mockFactory.Object;
        }
    }
}