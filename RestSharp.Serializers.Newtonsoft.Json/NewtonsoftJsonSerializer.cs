#region License
//   Copyright 2010 John Sheehan
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion
#region Acknowledgements
// Original JsonSerializer contributed by Daniel Crenna (@dimebrain)
#endregion

using System;
using System.IO;
using System.Threading;
using Newtonsoft.Json;
using RestSharp.Deserializers;

namespace RestSharp.Serializers.Newtonsoft.Json
{
    /// <summary>
    /// Default JSON serializer for request bodies
    /// Doesn't currently use the SerializeAs attribute, defers to Newtonsoft's attributes
    /// </summary>
    public class NewtonsoftJsonSerializer : ISerializer, IDeserializer
    {
        #region Fields & Properties

        /// <summary>
        /// Gets the default NewtonsoftJsonSerializer instance.
        /// </summary>
        /// <value>
        /// The default.
        /// </value>
        public static NewtonsoftJsonSerializer Default => _default.Value;

        /// <summary>
        /// The default instance holder.
        /// </summary>
        private static readonly Lazy<NewtonsoftJsonSerializer> _default = 
            new Lazy<NewtonsoftJsonSerializer>(LazyThreadSafetyMode.PublicationOnly);

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }
        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
        /// <summary>
        /// Content type for serialized content
        /// </summary>
        public string ContentType { get; set; }

        /// <summary>
        /// The serializer implementation.
        /// </summary>
        private readonly global::Newtonsoft.Json.JsonSerializer _serializer;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonSerializer"/> class.
        /// </summary>
        public NewtonsoftJsonSerializer()
        {
            ContentType = "application/json";
            _serializer = new global::Newtonsoft.Json.JsonSerializer
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Include,
                DefaultValueHandling = DefaultValueHandling.Include
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NewtonsoftJsonSerializer"/> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        public NewtonsoftJsonSerializer(global::Newtonsoft.Json.JsonSerializer serializer)
        {
            ContentType = "application/json";
            _serializer = serializer;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Serialize the object as JSON
        /// </summary>
        /// <param name="obj">Object to serialize</param>
        /// <returns>JSON as String</returns>
        public string Serialize(object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                using (var jsonTextWriter = new JsonTextWriter(stringWriter))
                {
                    _serializer.Serialize(jsonTextWriter, obj);

                    return stringWriter.ToString();
                }
            }
        }

        /// <summary>
        /// Deserializes the specified response.
        /// </summary>
        /// <typeparam name="T">The response type.</typeparam>
        /// <param name="response">The response.</param>
        /// <returns>The strongly-typed deserialized response.</returns>
        public T Deserialize<T>(IRestResponse response)
        {
            var content = response.Content;

            using (var stringReader = new StringReader(content))
            {
                using (var jsonTextReader = new JsonTextReader(stringReader))
                {
                    return _serializer.Deserialize<T>(jsonTextReader);
                }
            }
        }

        #endregion
    }
}