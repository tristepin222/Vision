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
        const int MAX_LABELCOUNT = 3;

        [TestInitialize()]
        public void Startup()
        {
            analyser = new GoogleAnalyser();
        }

        [TestMethod]
        public void Analyse_DefaultImage_IsntNull()
        {
            IImageData img = analyser.Analyse(imageSource);
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void Analyse_ImageWithMaxLabelCount_ReturnsThree()
        {
            IImageData img = analyser.Analyse(imageSource, MAX_LABELCOUNT);
            Assert.IsTrue(img.Labels.Count() >= 3);
        }

        [TestMethod]
        public void Analyse_ImageWithMaxConfidence_ReturnsBelowMaxConfidence()
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
        public void Analyse_ImageWithMaxConfidenceAndMaxLabel_ReturnsBelowMaxConfidenceAndLabelCount()
        {
            int maxConf = 50;
            bool hasPassed = true;
            IImageData img = analyser.Analyse(imageSource, MAX_LABELCOUNT, maxConf);

            foreach (var conf in img.Confidences)
            {
                if (conf > maxConf)
                {
                    hasPassed = false;
                }
            }
            Assert.IsTrue(hasPassed && img.Labels.Count() >= MAX_LABELCOUNT);
        }
    }
}