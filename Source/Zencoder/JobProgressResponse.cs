using System;
using Newtonsoft.Json;

namespace Zencoder
{
    /// <summary>
    /// Implements the job progress response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobProgressResponse : Response<JobProgressRequest, JobProgressResponse>
    {
        /// <summary>
        /// Input Status
        /// </summary>
        [JsonProperty("input")]
        public JobInputProgressResponse Input { get; set; }

        /// <summary>
        /// Output Collection
        /// </summary>
        [JsonProperty("outputs")]
        public JobOutputProgressResponse[] Outputs { get; set; }

        /// <summary>
        /// Overall percentage of completion.
        /// </summary>
        [JsonProperty("progress")]
        public double Progress { get; set; }

        /// <summary>
        /// Gets or sets the output's current state.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }
    }
}