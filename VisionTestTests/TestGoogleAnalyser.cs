using VisionTest.Analysers;
using VisionTest.Interfaces;

namespace VisionTestTests
{
    [TestClass]
    public class TestGoogleAnalyser
    {
        string localFile = "20230727_140005.jpg";
        string remoteFileUrl = "20230727_140005.jpg";
        int maxLabels = 3;
        public IImageData img;
        GoogleLabelDetectorImpl labelDetector;
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
            IImageData response =  this.labelDetector.Analyze(localFile);
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
            IImageData response = this.labelDetector.Analyze(remoteFileUrl);
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
            int maxLabel = 5;

            //when
            IImageData response =  this.labelDetector.Analyze(remoteFileUrl, maxLabels);
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
            IImageData response =  labelDetector.Analyze(remoteFileUrl, minConfidenceLevel);
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
            IImageData response =  this.labelDetector.Analyze(remoteFileUrl, maxLabels, minConfidenceLevel);
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