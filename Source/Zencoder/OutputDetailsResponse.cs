//-----------------------------------------------------------------------
// <copyright file="OutputDetailsResponse.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Implements the output details response.
    /// </summary>
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class OutputDetailsResponse : Response<OutputDetailsRequest, OutputDetailsResponse>
    {
        /// <summary>
        /// Gets or sets the file's audio bitrate (in Kbps).
        /// </summary>
        [JsonProperty("audio_bitrate_in_kbps")]
        public int? AudioBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the file's audio codec.
        /// </summary>
        [JsonProperty("audio_codec")]
        public AudioCodec? AudioCodec { get; set; }

        /// <summary>
        /// Gets or sets the file's audio sample rate.
        /// </summary>
        [JsonProperty("audio_sample_rate")]
        public int? AudioSampleRate { get; set; }

        /// <summary>
        /// Gets or sets the number of audio channels in the file.
        /// </summary>
        [JsonProperty("channels")]
        public int? Channels { get; set; }

        /// <summary>
        /// Gets or sets the file's duration (in ms).
        /// </summary>
        [JsonProperty("duration_in_ms")]
        public long? DurationInMiliseconds { get; set; }

        /// <summary>
        /// Gets or sets the file's size in bytes.
        /// </summary>
        [JsonProperty("file_size_in_bytes")]
        public int? FileSizeBytes { get; set; }

        /// <summary>
        /// Gets or sets the file's format.
        /// </summary>
        [JsonProperty("format")]
        public MediaFileFormat Format { get; set; }

        /// <summary>
        /// Gets or sets the file's frame rate.
        /// </summary>
        [JsonProperty("frame_rate")]
        public float? FrameRate { get; set; }

        /// <summary>
        /// Gets or sets the file's height.
        /// </summary>
        [JsonProperty("height")]
        public int? Height { get; set; }

        /// <summary>
        /// Gets or sets the file's ID.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the label.
        /// </summary>
        [JsonProperty("label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the file's state with respect to its parent job.
        /// </summary>
        [JsonProperty("state")]
        public OutputState State { get; set; }

        /// <summary>
        /// Gets or sets the file's total bitrate (in Kbps).
        /// </summary>
        [JsonProperty("total_bitrate_in_kbps")]
        public int? TotalBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the file's URL.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the file's video bitrate (in Kbps).
        /// </summary>
        [JsonProperty("video_bitrate_in_kbps")]
        public int? VideoBitrateInKbps { get; set; }

        /// <summary>
        /// Gets or sets the file's video codec.
        /// </summary>
        [JsonProperty("video_codec")]
        public OutputVideoCodec? VideoCodec { get; set; }

        /// <summary>
        /// Gets or sets the file's width.
        /// </summary>
        [JsonProperty("width")]
        public int? Width { get; set; }

        /// <summary>
        /// Gets or sets the MD5 checksum.
        /// </summary>
        [JsonProperty("md5_checksum")]
        public string Md5Checksum { get; set; }

    }
}
