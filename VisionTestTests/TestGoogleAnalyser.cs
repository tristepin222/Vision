using VisionTest.Analysers;
using VisionTest.Datas;
using VisionTest.Interfaces;

namespace VisionTestTests
{
    [TestClass]
    public class TestGoogleAnalyser
    {
        string localFile = Environment.GetEnvironmentVariable("Image");
        string remoteFileUrl = Environment.GetEnvironmentVariable("Image");
        int maxLabels = 3;
        public IImageData img = new GoogleImageData("", new string[1], new float[1]);
        GoogleLabelDetectorImpl labelDetector = new GoogleLabelDetectorImpl();
        const int MAX_LABELCOUNT = 3;

        [TestInitialize()]
        public void Startup()
        {
            labelDetector = new GoogleLabelDetectorImpl();
        }

        [TestMethod]
        public async Task Analyze_LocalFileWithDefaultValues_ImageAnalyzed()
        {
            //given
            Assert.IsTrue(File.Exists(localFile));

            //when
            IImageData response = await this.labelDetector.Analyze(localFile);
            //TODO the type of response contains the payload (returned in json by the api)

            //then
            Assert.IsTrue(response.Labels.Count() <= 10);
            foreach (int metric in response.Confidences)
            {
                Assert.IsTrue(metric >= 90);
            }
        }
        [TestMethod]
        public async Task Analyze_RemoteImageWithDefaultValues_ImageAnalyzed()
        {
            //given
            //TODO test if the remote file is available

            //when
            IImageData response = await this.labelDetector.Analyze(remoteFileUrl);
            //TODO the type of response contains the payload (returned in json by the api)

            //then
            Assert.IsTrue(response.Labels.Count() <= 10);
            foreach (int metric in response.Confidences)
            {
                Assert.IsTrue(metric >= 90);
            }
        }
        [TestMethod]
        public async Task Analyze_RemoteImageWithCustomMaxLabelValue_ImageAnalyzed()
        {
            //given
            //TODO test if the remote file is available

            //when
            IImageData response = await this.labelDetector.Analyze(remoteFileUrl, maxLabels);
            //TODO the type of response contains the payload (returned in json by the api)

            //then
            Assert.IsTrue(response.Labels.Count() <= maxLabels);
            foreach (int metric in response.Confidences)
            {
                Assert.IsTrue(metric >= 90);
            }
        }

        [TestMethod]
        public async Task Analyze_RemoteImageWithCustomMinConfidenceLevelValue_ImageAnalyzed()
        {
            //given
            //TODO test if the remote file is available
            int minConfidenceLevel = 60;

            //when
            IImageData response = await labelDetector.Analyze(remoteFileUrl, minConfidenceLevel);
            //TODO the type of response contains the payload (returned in json by the api)

            //then
            Assert.IsTrue(response.Labels.Count() <= 10);
            foreach (int metric in response.Confidences)
            {
                Assert.IsTrue(metric >= minConfidenceLevel);
            }
        }

        [TestMethod]
        public async Task Analyze_RemoteImageWithCustomValues_ImageAnalyzed()
        {
            //given
            //TODO test if the remote file is available
            int maxLabels = 5;
            int minConfidenceLevel = 60;

            //when
            IImageData response = await this.labelDetector.Analyze(remoteFileUrl, maxLabels, minConfidenceLevel);
            //TODO the type of response contains the payload (returned in json by the api)

            //then
            Assert.IsTrue(response.Labels.Count() <= maxLabels);
            foreach (int metric in response.Confidences)
            {
                Assert.IsTrue(metric >= minConfidenceLevel);
            }
        }
    }
}