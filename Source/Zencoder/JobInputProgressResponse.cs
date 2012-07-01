using System;
using Newtonsoft.Json;

namespace Zencoder
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobInputProgressResponse : Response<JobProgressRequest, JobProgressResponse>
    {
        /// <summary>
        /// Gets or sets the input's Id
        /// </summary>
        [JsonProperty("id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the output's current state.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }
    }
}