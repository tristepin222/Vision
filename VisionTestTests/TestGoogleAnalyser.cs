using VisionTest.Analysers;
using VisionTest.Interfaces;

namespace VisionTestTests
{
    [TestClass]
    public class TestGoogleAnalyser
    {
        string imageSource = "20230727_140005.jpg";
        public IImageData img;
        GoogleLabelDetectorImpl analyser;
        const int MAX_LABELCOUNT = 3;

        [TestInitialize()]
        public void Startup()
        {
            analyser = new GoogleLabelDetectorImpl();
        }

        [TestMethod]
        public void Analyse_DefaultImage_IsntNull()
        {
            //given
            IImageData img = analyser.Analyse(imageSource);

            //then
            Assert.IsNotNull(img);
        }

        [TestMethod]
        public void Analyse_ImageWithMaxLabelCount_ReturnsThree()
        {
            //given
            IImageData img = analyser.Analyse(imageSource, MAX_LABELCOUNT);

            //then
            Assert.IsTrue(img.Labels.Count() >= 3);
        }

        [TestMethod]
        public void Analyse_ImageWithMaxConfidence_ReturnsBelowMaxConfidence()
        {

            //given
            int maxConf = 50;
            bool hasPassed = true;
            IImageData img = analyser.Analyse(imageSource, maxConfidenceAmount: maxConf);

            //when
            foreach (var conf in img.Confidences) 
            { 
                if(conf > maxConf)
                {
                    hasPassed = false;
                }
            }

            //then
            Assert.IsTrue(hasPassed);
        }

        [TestMethod]
        public void Analyse_ImageWithMaxConfidenceAndMaxLabel_ReturnsBelowMaxConfidenceAndLabelCount()
        {
            //given
            int maxConf = 50;
            bool hasPassed = true;
            IImageData img = analyser.Analyse(imageSource, MAX_LABELCOUNT, maxConf);


            //when
            foreach (var conf in img.Confidences)
            {
                if (conf > maxConf)
                {
                    hasPassed = false;
                }
            }

            //then
            Assert.IsTrue(hasPassed && img.Labels.Count() >= MAX_LABELCOUNT);
        }
    }
}