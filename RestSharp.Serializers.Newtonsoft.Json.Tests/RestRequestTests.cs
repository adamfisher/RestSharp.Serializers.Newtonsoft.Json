using FluentAssertions;
using Xunit;

namespace RestSharp.Serializers.Newtonsoft.Json.Tests
{
    public class RestRequestTests
    {
        [Fact]
        public void CreatingANewRestClient_WithTheDefaultConstructor_UsesNewtonSoftJsonSerializer()
        {
            var request = new RestRequest();

            request.JsonSerializer.Should().BeOfType<NewtonsoftJsonSerializer>();
        }

        [Fact]
        public void CreatingANewRestClient_WithMethodConstructor_UsesNewtonSoftJsonSerializer()
        {
            var request = new RestRequest(Method.GET);

            request.JsonSerializer.Should().BeOfType<NewtonsoftJsonSerializer>();
        }

        [Fact]
        public void CreatingANewRestClient_WithBaseUrlAndMethod_UsesNewtonSoftJsonSerializer()
        {
            var request = new RestRequest("http://www.google.com", Method.GET);

            request.JsonSerializer.Should().BeOfType<NewtonsoftJsonSerializer>();
        }
    }
}
