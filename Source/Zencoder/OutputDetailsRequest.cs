namespace Zencoder
{
    using System;
    using System.Globalization;
    using System.Web;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the output details request.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OutputDetailsRequest : Request<OutputDetailsRequest, OutputDetailsResponse>
    {
        private Uri url;

        /// <summary>
        /// Initializes a new instance of the OutputDetailsRequest class.
        /// </summary>
        /// <param name="zencoder">The <see cref="Zencoder"/> service to create the request with.</param>
        public OutputDetailsRequest(Zencoder zencoder)
            : base(zencoder)
        {
        }

        /// <summary>
        /// Initializes a new instance of the OutputDetailsRequest class.
        /// </summary>
        /// <param name="apiKey">The API key to use when connecting to the service.</param>
        /// <param name="baseUrl">The service base URL.</param>
        public OutputDetailsRequest(string apiKey, Uri baseUrl)
            : base(apiKey, baseUrl)
        {
        }

        /// <summary>
        /// Gets or sets the ID of the output to get details for.
        /// </summary>
        public int OutputId { get; set; }

        /// <summary>
        /// Gets the concrete URL this request will call.
        /// </summary>
        public override Uri Url
        {
            get 
            {
                if (this.OutputId < 1)
                {
                    throw new InvalidOperationException("OutputId must be set before generating the request URL.");
                }

                return this.url ?? (this.url = BaseUrl.AppendPath(string.Concat("outputs/", this.OutputId)).WithApiKey(ApiKey)); 
            }
        }

        /// <summary>
        /// Gets the HTTP verb to use when making the request.
        /// </summary>
        public override HttpVerb Verb
        {
            get { return HttpVerb.GET; }
        }
    }
}
