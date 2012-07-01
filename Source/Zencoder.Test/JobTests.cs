//-----------------------------------------------------------------------
// <copyright file="JobTests.cs" company="Tasty Codes">
//     Copyright (c) 2010 Chad Burggraf.
// </copyright>
//-----------------------------------------------------------------------

namespace Zencoder.Test
{
    using System;
    using System.Linq;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    /// <summary>
    /// Job tests.
    /// </summary>
    [TestClass]
    public class JobTests : TestBase
    {
        /// <summary>
        /// Cancel job request tests.
        /// </summary>
        [TestMethod]
        public void JobCancelJobRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            CancelJobResponse cancelResponse = Zencoder.CancelJob(createResponse.Id);
            Assert.IsTrue(cancelResponse.Success);
        }

        /// <summary>
        /// Cancel job request tests.
        /// </summary>
        [TestMethod]
        public void JobCancelJobRequestAsync()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            CancelJobResponse asyncResponse = null;

            Zencoder.CancelJob(
                createResponse.Id,
                r =>
                    {
                        asyncResponse = r;
                        handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
            Assert.IsNotNull(asyncResponse);
            Assert.IsTrue(asyncResponse.Success);
        }

        /// <summary>
        /// Create job request tests.
        /// </summary>
        [TestMethod]
        public void JobCreateJobRequest()
        {
            Output[] outputs = new Output[]
            {
                new Output()
                {
                    Label = "iPhone",
                    Url = "s3://output-bucket/output-file-1-name.mp4",
                    Width = 480,
                    Height = 320
                },
                new Output() 
                {
                    Label = "WebHD",
                    Url = "s3://output-bucket/output-file-2-name.mp4",
                    Width = 1280,
                    Height = 720
                }
            };

            CreateJobResponse response = Zencoder.CreateJob("s3://bucket-name/file-name.avi", outputs, null, null, true, true);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(outputs.Count(), response.Outputs.Count());
            
            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                true,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    Assert.IsTrue(r.Outputs.Count() > 0);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Delete job request tests.
        /// </summary>
        [TestMethod]
        public void JobDeleteJobRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            // TODO: Investigate whether Zencoder has truly deprecated this API operation.
            // For now, just test for an InConflict status, because that's what it seems
            // we should expect.
            DeleteJobResponse deleteResponse = Zencoder.DeleteJob(createResponse.Id);
            Assert.IsTrue(deleteResponse.InConflict);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.DeleteJob(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.InConflict);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Job details request tests.
        /// </summary>
        [TestMethod]
        public void JobJobDetailsRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            JobDetailsResponse detailsResponse = Zencoder.JobDetails(createResponse.Id);
            Assert.IsTrue(detailsResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.JobDetails(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }

        /// <summary>
        /// Job progress request tests.
        /// </summary>
        [TestMethod]
        public void JobJobOutputProgressRequest()
        {
            Output output = new Output()
            {
                Label = "iPhone",
                Url = "s3://output-bucket/output-file-1-name.mp4",
                Width = 480,
                Height = 320
            };

            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", new Output[] { output });
            Assert.IsTrue(createResponse.Success);

            JobOutputProgressResponse progressResponse = Zencoder.JobOutputProgress(createResponse.Outputs.First().Id);
            Assert.IsTrue(progressResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.JobOutputProgress(
                createResponse.Outputs.First().Id,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }


        /// <summary>
        /// Job progress request tests.
        /// </summary>
        [TestMethod]
        public void JobJobProgressRequest()
        {
            Output output = new Output()
            {
                Label = "iPhone",
                Url = "s3://output-bucket/output-file-1-name.mp4",
                Width = 480,
                Height = 320
            };

            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", new Output[] { output });
            Assert.IsTrue(createResponse.Success);

            JobProgressResponse progressResponse = Zencoder.JobProgress(createResponse.Id);
            Assert.IsTrue(progressResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            JobProgressResponse asyncResult = null;

            Zencoder.JobProgress(
                createResponse.Id,
                r =>
                    {
                        asyncResult = r;
                        handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
            Assert.IsNotNull(asyncResult);
            Assert.IsTrue(asyncResult.Success);
        }

        /// <summary>
        /// List jobs request tests.
        /// </summary>
        [TestMethod]
        public void JobListJobsRequest()
        {
            ListJobsResponse response = Zencoder.ListJobs();
            Assert.IsTrue(response.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.ListJobs(
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }
        
        /// <summary>
        /// Nested async job request tests.
        /// </summary>
        [TestMethod]
        public void JobNestedAsyncRequests()
        {
            ManualResetEvent[] handles = new ManualResetEvent[] 
            { 
                new ManualResetEvent(false),
                new ManualResetEvent(false)
            };

            // Nested async calls.
            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                false,
                r =>
                {
                    Assert.IsTrue(r.Success);

                    Zencoder.JobDetails(
                        r.Id,
                        dr =>
                        {
                            Assert.IsTrue(dr.Success);
                            handles[0].Set();
                        });
                });

            // Async call then a sync call.
            Zencoder.CreateJob(
                "s3://bucket-name/file-name.avi",
                null,
                3,
                "asia",
                true,
                false,
                r =>
                {
                    Assert.IsTrue(r.Success);
                    Assert.IsTrue(Zencoder.JobDetails(r.Id).Success);
                    handles[1].Set();
                });

            foreach (var handle in handles)
            {
                handle.WaitOne();
            }
        }

        /// <summary>
        /// Resubmit job request tests.
        /// </summary>
        [TestMethod]
        public void JobResubmitJobRequest()
        {
            CreateJobResponse createResponse = Zencoder.CreateJob("s3://bucket-name/file-name.avi", null, null, null, true, false);
            Assert.IsTrue(createResponse.Success);

            ResubmitJobResponse resubmitResponse = Zencoder.ResubmitJob(createResponse.Id);
            Assert.IsTrue(resubmitResponse.Success);

            AutoResetEvent[] handles = new AutoResetEvent[] { new AutoResetEvent(false) };

            Zencoder.ResubmitJob(
                createResponse.Id, 
                r =>
                {
                    Assert.IsTrue(r.Success);
                    handles[0].Set();
                });

            WaitHandle.WaitAll(handles);
        }
    }
}
