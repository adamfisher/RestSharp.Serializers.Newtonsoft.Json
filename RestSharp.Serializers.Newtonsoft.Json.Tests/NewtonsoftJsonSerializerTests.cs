using System;
using FluentAssertions;
using Xunit;

namespace RestSharp.Serializers.Newtonsoft.Json.Tests
{
    public class NewtonsoftJsonSerializerTests
    {
        #region Fields & Properties

        private Person PersonObject => new Person()
        {
            Name = "John Smith",
            FavoriteNumber = 34,
            FavoriteColor = ConsoleColor.Red,
            HasChildren = true,
            NetWorth = 231453.56,
            DateOfBirth = new DateTime(1956, 8, 12)
        };

        private string PersonString => 
            "{\"Name\":\"John Smith\",\"FavoriteNumber\":34,\"FavoriteColor\":12,\"HasChildren\":true,\"NetWorth\":231453.56,\"DateOfBirth\":\"1956-08-12T00:00:00\"}";

        #endregion

        [Fact]
        public void Serialize()
        {
            var serializer = NewtonsoftJsonSerializer.Default;
            var result = serializer.Serialize(PersonObject);

            result.Should().BeEquivalentTo(PersonString);
        }

        [Fact]
        public void Deserialize()
        {
            var serializer = NewtonsoftJsonSerializer.Default;
            var restResponse = new RestResponse() {Content = PersonString};
            var result = serializer.Deserialize<Person>(restResponse);

            result.Should().BeEquivalentTo(PersonObject);
        }

        public class Person
        {
            public string Name { get; set; }
            public int FavoriteNumber { get; set; }
            public ConsoleColor FavoriteColor { get; set; }
            public bool HasChildren { get; set; }
            public double NetWorth { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
