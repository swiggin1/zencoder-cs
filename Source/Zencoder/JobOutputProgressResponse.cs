//-----------------------------------------------------------------------
// <copyright file="JobOutputProgressResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the job progress response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class JobOutputProgressResponse : Response<JobOutputProgressRequest, JobOutputProgressResponse>
    {
        /// <summary>
        /// Gets or sets the event currently in progress for the output.
        /// </summary>
        [JsonProperty("current_event")]
        public OutputEvent CurrentEvent { get; set; }

        /// <summary>
        /// Overall percentage of completion.
        /// </summary>
        [JsonProperty("progress")]
        public double Progress { get; set; }

        /// <summary>
        /// Gets or sets the progress of <see cref="CurrentEvent"/>.
        /// </summary>
        [JsonProperty("current_event_progress")]
        public double CurrentEventProgress { get; set; }

        /// <summary>
        /// Gets or sets the output's current state.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }
    }
}
