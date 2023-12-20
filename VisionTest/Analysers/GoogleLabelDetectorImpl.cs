using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using VisionTest.Datas;
using VisionTest.Interfaces;

namespace VisionTest.Analysers
{
    public class GoogleLabelDetectorImpl : ILabelDetector
    {
        ImageAnnotatorClient client;
        public GoogleLabelDetectorImpl()
        {
            client = ImageAnnotatorClient.Create();
        }
        public IImageData Analyze(string imageString, int labelAmount = 10, int minConfidenceAmount = 90)
        {
            List<string> labels = new List<string>();
            List<float> confidences = new List<float>();
            Image image = Image.FromFile(imageString);
            IReadOnlyList<EntityAnnotation> results = client.DetectLabels(image, maxResults: labelAmount);

            int index = 0;
            foreach (EntityAnnotation result in results)
            {

                if (result.Score*100 >= minConfidenceAmount && index <= labelAmount)
                {
                    confidences.Add(result.Score * 100);
                    labels.Add(result.Description);
                }
                index++;
            }
            return new GoogleImageData(imageString, labels.ToArray(), confidences.ToArray());
        }
    }
}
