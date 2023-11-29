using VisionTest;
using VisionTest.Interfaces;

namespace VisionTestTests
{
    [TestClass]
    public class TestGoogleAnalyser
    {
        string imageSource = "20230727_140005.jpg";
        public IImageData img;
        GoogleAnalyser analyser;

        [TestInitialize()]
        public void Startup()
        {
            analyser = new GoogleAnalyser();
            img = analyser.Analyse(imageSource,3, 50);
        }

        [TestMethod]
        public void DefaultTest()
        {
            IImageData img = analyser.Analyse(imageSource);
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void LabelTest()
        {
            IImageData img = analyser.Analyse(imageSource, 3);
            Assert.IsTrue(img.Labels.Count() >= this.img.Labels.Count());
        }

        [TestMethod]
        public void ConfidenceTest()
        {
            int maxConf = 50;
            bool hasPassed = true;
            IImageData img = analyser.Analyse(imageSource, maxConfidenceAmount: maxConf);

            foreach (var conf in img.Confidences) 
            { 
                if(conf > maxConf)
                {
                    hasPassed = false;
                }
            }
            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void ConfidenceAndLabelTest()
        {
            int maxConf = 50;
            bool hasPassed = true;
            IImageData img = analyser.Analyse(imageSource,3,maxConf);

            foreach (var conf in img.Confidences)
            {
                if (conf > maxConf)
                {
                    hasPassed = false;
                }
            }
            Assert.IsTrue(hasPassed && img.Labels.Count() >= this.img.Labels.Count());
        }
    }
}