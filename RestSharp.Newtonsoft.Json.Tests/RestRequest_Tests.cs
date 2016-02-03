using FakeItEasy;
using FakeItEasy.Configuration;
using Machine.Specifications;
using RestSharp.Serializers;

namespace RestSharp.Newtonsoft.Json.Tests
{
    [Subject(typeof(RestRequest))]
    public class When_making_a_REST_request
    {
        protected static IRestClient client;
        protected static IRestRequest request;
        protected static IRestResponse response;
        protected static IReturnValueArgumentValidationConfiguration<ISerializer> ACallToGetTheNewtonSoftJsonSerializer;

        private Establish context = () =>
        {
            client = A.Fake<IRestClient>();
            A.CallTo(() => client.Execute(A<IRestRequest>._)).Returns(new RestResponse());

            request = A.Fake<IRestRequest>();
            A.CallTo(() => request.AddBody(A<object>._, A<string>._)).Returns(request);

            ACallToGetTheNewtonSoftJsonSerializer = A.CallTo(() => request.JsonSerializer);
            request.AddJsonBody(null);
        };

        private Because of = () =>
        {
            response = client.Execute(request);
        };

        private It Should_return_a_non_empty_response = () => response.ShouldNotBeNull();

        private It Should_use_the_NewtonSoft_JSON_serializer = () => ACallToGetTheNewtonSoftJsonSerializer.ShouldBeOfExactType<NewtonsoftJsonSerializer>();
    }
}
