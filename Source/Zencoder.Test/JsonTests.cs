using System;
using System.Globalization;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Zencoder.Test
{
    /// <summary>
    /// Json tests.
    /// </summary>
    [TestClass]
    public class JsonTests : TestBase
    {
        /// <summary>
        /// Test JSON for job details response deserialization.
        /// </summary>
        private const string JobDetailsResponseJson =
            @"{
              ""job"": {
                ""created_at"": ""2010-01-01T00:00:00Z"",
                ""finished_at"": ""2010-01-01T00:00:00Z"",
                ""updated_at"": ""2010-01-01T00:00:00Z"",
                ""submitted_at"": ""2010-01-01T00:00:00Z"",
                ""pass_through"": null,
                ""id"": 1,
                ""input_media_file"": {
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 48000,
                  ""url"": ""s3://bucket/test.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 95,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1862748,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 498,
                  ""state"": ""finished""
                },
                ""test"": false,
                ""output_media_files"": [{
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 44100,
                  ""url"": ""http://s3.amazonaws.com/bucket/video.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 92,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1386663,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 351,
                  ""state"": ""finished"",
                  ""label"": ""Web""
                }],
                ""thumbnails"": [{
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0000.png"",
                  ""id"": 1
                }],
                ""state"": ""finished""
              }
            }";

        /// <summary>
        /// Test JSON for job details response deserialization.
        /// Note additional new test values including: total_bitrate_in_kbps,
        /// non-integer framerate, thumbnail group label, thumbnail format
        /// </summary>
        private const string JobDetailsResponseTestSetTwoJson =
            @"{
              ""job"": {
              ""created_at"": ""2011-04-04T11:21:14-05:00"",
              ""finished_at"": ""2011-04-04T11:22:16-05:00"",
              ""updated_at"": ""2011-04-04T11:22:16-05:00"",
              ""submitted_at"": ""2011-04-04T11:21:14-05:00"",
                ""pass_through"": null,
                ""id"": 1,
                ""input_media_file"": {
                  ""total_bitrate_in_kbps"": 6524,
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2011-04-04T18:21:14+02:00"",
                  ""frame_rate"": 25.05,
                  ""finished_at"": ""2011-04-04T18:21:32+02:00"",
                  ""updated_at"": ""2011-04-04T18:21:32+02:00"",
                  ""duration_in_ms"": 122000,
                  ""audio_sample_rate"": 32000,
                  ""url"": ""http://example.com/test.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 1024,
                  ""audio_codec"": ""pcm_s16le"",
                  ""height"": 576,
                  ""file_size_bytes"": 100299080,
                  ""video_codec"": ""h264"",
                  ""test"": true,
                  ""channels"": ""2"",
                  ""width"": 720,
                  ""video_bitrate_in_kbps"": 5500,
                  ""state"": ""finished""
                },
                ""test"": false,
                ""output_media_files"": [{
                  ""total_bitrate_in_kbps"": 586,
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 5080,
                  ""audio_sample_rate"": 32000,
                  ""url"": ""http://s3.amazonaws.com/bucket/video.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 60,
                  ""audio_codec"": ""aac"",
                  ""height"": 360,
                  ""file_size_bytes"": 375236,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 640,
                  ""video_bitrate_in_kbps"": 526,
                  ""state"": ""finished"",
                  ""label"": ""Web""
                }],
                ""thumbnails"": [{
                  ""group_label"": ""group-label-value-1"",
                  ""format"": ""png"",
                  ""created_at"": ""2011-04-04T11:22:16-05:00"",
                  ""updated_at"": ""2011-04-04T11:22:16-05:00"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0000.png"",
                  ""id"": 1,
                  ""height"": 360,
                  ""file_size_bytes"": 417387,
                  ""width"": 640
                  },
                  {
                  ""group_label"": ""group-label-value-1"",
                  ""format"": ""png"",
                  ""created_at"": ""2011-04-04T11:22:16-05:00"",
                  ""updated_at"": ""2011-04-04T11:22:16-05:00"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0001.png"",
                  ""id"": 5829389,
                  ""height"": 360,
                  ""file_size_bytes"": 382938,
                  ""width"": 640
                }],
                ""state"": ""finished""
              }
            }";


        /// <summary>
        /// Test JSON for list jobs response deserialization.
        /// </summary>
        private const string ListJobsResponseJson =
            @"[{
              ""job"": {
                ""created_at"": ""2010-01-01T00:00:00Z"",
                ""finished_at"": ""2010-01-01T00:00:00Z"",
                ""updated_at"": ""2010-01-01T00:00:00Z"",
                ""submitted_at"": ""2010-01-01T00:00:00Z"",
                ""pass_through"": null,
                ""id"": 1,
                ""input_media_file"": {
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 48000,
                  ""url"": ""s3://bucket/test.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 95,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1862748,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 498,
                  ""state"": ""finished""
                },
                ""test"": false,
                ""output_media_files"": [{
                  ""format"": ""mpeg4"",
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""frame_rate"": 29,
                  ""finished_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""duration_in_ms"": 24883,
                  ""audio_sample_rate"": 44100,
                  ""url"": ""http://s3.amazonaws.com/bucket/video.mp4"",
                  ""id"": 1,
                  ""error_message"": null,
                  ""error_class"": null,
                  ""audio_bitrate_in_kbps"": 92,
                  ""audio_codec"": ""aac"",
                  ""height"": 352,
                  ""file_size_bytes"": 1386663,
                  ""video_codec"": ""h264"",
                  ""test"": false,
                  ""channels"": ""2"",
                  ""width"": 624,
                  ""video_bitrate_in_kbps"": 351,
                  ""state"": ""finished"",
                  ""label"": ""Web""
                }],
                ""thumbnails"": [{
                  ""created_at"": ""2010-01-01T00:00:00Z"",
                  ""updated_at"": ""2010-01-01T00:00:00Z"",
                  ""url"": ""http://s3.amazonaws.com/bucket/video/frame_0000.png"",
                  ""id"": 1
                }],
                ""state"": ""finished""
              }
            }]";

        /// <summary>
        /// Create job request to JSON tests.
        /// </summary>
        [TestMethod]
        public void JobCreateJobRequestToJson()
        {
            const string One = @"{{""input"":""s3://bucket-name/file-name.avi"",""api_key"":""{0}""}}";
            const string Two = @"{{""download_connections"":3,""input"":""s3://bucket-name/file-name.avi"",""region"":""asia"",""api_key"":""{0}""}}";

            CreateJobRequest request = new CreateJobRequest(Zencoder)
                                           {
                                               Input = "s3://bucket-name/file-name.avi"
                                           };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, One, ApiKey), request.ToJson());

            request = new CreateJobRequest(Zencoder)
                          {
                              DownloadConnections = 3,
                              Input = "s3://bucket-name/file-name.avi",
                              Region = "asia"
                          };

            Assert.AreEqual(string.Format(CultureInfo.InvariantCulture, Two, ApiKey), request.ToJson());
        }

        /// <summary>
        /// Create job response from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobCreateJobResponseFromJson()
        {
            CreateJobResponse response = CreateJobResponse.FromJson(@"{""id"":""1234"",""outputs"":[{""id"":""4321""}]}");
            Assert.AreEqual(1234, response.Id);
            Assert.AreEqual(1, response.Outputs.Length);
            Assert.AreEqual(4321, response.Outputs.First().Id);
        }

        /// <summary>
        /// Job details from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobDetailsFromJson()
        {
            JobDetailsResponse response = JobDetailsResponse.FromJson(JobDetailsResponseJson);
            Assert.AreEqual(new DateTime(2010, 1, 1), response.Job.FinishedAt);
            Assert.AreEqual(1, response.Job.Id);
            Assert.AreEqual(JobState.Finished, response.Job.State);

            Assert.AreEqual("mpeg4", response.Job.InputMediaFile.Format);
            Assert.AreEqual(24883, response.Job.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, response.Job.InputMediaFile.Channels);
            Assert.AreEqual("h264", response.Job.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, response.Job.OutputMediaFiles.Length);
        }

        /// <summary>
        /// Job details from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobDetailsTestSetTwoFromJson()
        {
            JobDetailsResponse response = JobDetailsResponse.FromJson(JobDetailsResponseTestSetTwoJson);
            Assert.AreEqual(new DateTimeOffset(2011, 4, 4, 11, 22, 16, TimeSpan.FromHours(-5)).ToUniversalTime(), response.Job.FinishedAt.Value.ToUniversalTime());
            Assert.AreEqual(1, response.Job.Id);
            Assert.AreEqual(JobState.Finished, response.Job.State);

            Assert.AreEqual("mpeg4", response.Job.InputMediaFile.Format);
            Assert.AreEqual(122000, response.Job.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, response.Job.InputMediaFile.Channels);
            Assert.AreEqual("h264", response.Job.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, response.Job.OutputMediaFiles.Length);

            Assert.AreEqual("pcm_s16le", response.Job.InputMediaFile.AudioCodec);
            Assert.AreEqual(25.05f, response.Job.InputMediaFile.FrameRate);
            Assert.AreEqual(6524, response.Job.InputMediaFile.TotalBitrateInKbps);
            Assert.AreEqual(586, response.Job.OutputMediaFiles[0].TotalBitrateInKbps);

            // TODO: implement ability to get thumbnail element of response.
            // Assert.AreEqual("group-label-value-1", response.Job.
        }

        /// <summary>
        /// Job progress response from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobOutputProgressResponseFromJson()
        {
            JobOutputProgressResponse response = JobOutputProgressResponse.FromJson(@"{""state"":""processing"",""current_event"":""Transcoding"",""progress"":""32.34567345""}");
            Assert.AreEqual(OutputState.Processing, response.State);
            Assert.AreEqual(OutputEvent.Transcoding, response.CurrentEvent);
            Assert.AreEqual(32.34567345, response.Progress);
        }

        /// <summary>
        /// Job progress response from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobJobProgressResponseFromJson()
        {
            JobProgressResponse response = JobProgressResponse.FromJson(@"{
                                                                      ""state"": ""processing"",
                                                                      ""progress"": 32.34567345,
                                                                      ""input"": {
                                                                        ""id"": 1234,
                                                                        ""state"": ""finished""
                                                                      },
                                                                      ""outputs"": [
                                                                        {
                                                                          ""id"": 4567,
                                                                          ""state"": ""processing"",
                                                                          ""current_event"": ""Transcoding"",
                                                                          ""current_event_progress"": 25.0323,
                                                                          ""progress"": 35.23532
                                                                        },
                                                                        {
                                                                          ""id"": 4568,
                                                                          ""state"": ""processing"",
                                                                          ""current_event"": ""Uploading"",
                                                                          ""current_event_progress"": 82.32,
                                                                          ""progress"": 95.3223
                                                                        }
                                                                      ]
                                                                    }");
            Assert.AreEqual(OutputState.Processing, response.State);
            Assert.AreEqual(32.34567345, response.Progress);

            Assert.AreEqual(1234, response.Input.Id);
            Assert.AreEqual(OutputState.Finished, response.Input.State);

            Assert.AreEqual(2, response.Outputs.Length);
            Assert.AreEqual(4567, response.Outputs[0].Id);
            Assert.AreEqual(OutputState.Processing, response.Outputs[0].State);
            Assert.AreEqual(OutputEvent.Transcoding, response.Outputs[0].CurrentEvent);
            Assert.AreEqual(25.0323, response.Outputs[0].CurrentEventProgress);
            Assert.AreEqual(35.23532, response.Outputs[0].Progress);
        }


        /// <summary>
        /// List jobs from JSON tests.
        /// </summary>
        [TestMethod]
        public void JobListJobsFromJson()
        {
            ListJobsResponse response = ListJobsResponse.FromJson(ListJobsResponseJson);
            Assert.AreEqual(1, response.Jobs.Length);

            Job first = response.Jobs.First();
            Assert.AreEqual(new DateTime(2010, 1, 1), first.FinishedAt);
            Assert.AreEqual(1, first.Id);
            Assert.AreEqual(JobState.Finished, first.State);

            Assert.AreEqual("mpeg4", first.InputMediaFile.Format);
            Assert.AreEqual(24883, first.InputMediaFile.DurationInMiliseconds);
            Assert.AreEqual(2, first.InputMediaFile.Channels);
            Assert.AreEqual("h264", first.InputMediaFile.VideoCodec);
            Assert.AreEqual(1, first.OutputMediaFiles.Length);

            OutputMediaFile output = first.OutputMediaFiles.First();
            Assert.AreEqual(AudioCodec.Aac, output.AudioCodec);
            Assert.AreEqual(false, output.Test);
        }
    }
}