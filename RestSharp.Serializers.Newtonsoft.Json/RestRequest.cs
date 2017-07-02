using System;

namespace RestSharp.Serializers.Newtonsoft.Json
{
    /// <summary>
    /// Container for data used to make requests.
    /// </summary>
    public class RestRequest : RestSharp.RestRequest
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RestRequest"/> class.
        /// </summary>
        public RestRequest()
        {
            IntializeJsonSerializer();
        }

        /// <summary>
        /// Sets Method property to value of method
        /// 
        /// </summary>
        /// <param name="method">Method to use for this request</param>
        public RestRequest(Method method) : base(method)
        {
            IntializeJsonSerializer();
        }

        /// <summary>
        /// Sets Resource property
        /// 
        /// </summary>
        /// <param name="resource">Resource to use for this request</param>
        public RestRequest(string resource) : base(resource)
        {
            IntializeJsonSerializer();
        }

        /// <summary>
        /// Sets Resource and Method properties
        /// 
        /// </summary>
        /// <param name="resource">Resource to use for this request</param><param name="method">Method to use for this request</param>
        public RestRequest(string resource, Method method) : base(resource, method)
        {
            IntializeJsonSerializer();
        }

        /// <summary>
        /// Sets Resource property
        /// 
        /// </summary>
        /// <param name="resource">Resource to use for this request</param>
        public RestRequest(Uri resource) : base(resource)
        {
            IntializeJsonSerializer();
        }

        /// <summary>
        /// Sets Resource and Method properties
        /// 
        /// </summary>
        /// <param name="resource">Resource to use for this request</param><param name="method">Method to use for this request</param>
        public RestRequest(Uri resource, Method method) : base(resource, method)
        {
            IntializeJsonSerializer();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Intializes the serializer.
        /// </summary>
        protected void IntializeJsonSerializer()
        {
            JsonSerializer = new NewtonsoftJsonSerializer();
        }

        #endregion
    }
}
