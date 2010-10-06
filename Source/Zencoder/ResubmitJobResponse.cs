﻿

namespace Zencoder
{
    using System;
    using System.Net;

    /// <summary>
    /// Implements the resubmit job response.
    /// </summary>
    public class ResubmitJobResponse : Response<ResubmitJobRequest, ResubmitJobResponse>
    {
        /// <summary>
        /// Gets a value indicating whether the service indicated that the resubmit request
        /// was invalid because the job was not in the "finished" state.
        /// </summary>
        public bool InConflict
        {
            get { return StatusCode == HttpStatusCode.Conflict; }
        }
    }
}
