using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionTest
{
    public class ImageData
    {
        Image imageSource;
        string[] labels;
        float[] confidences;
        public ImageData(Image imageSource, string[] labels, float[] confidences)
        {
            this.imageSource = imageSource;
            this.labels = labels;
            this.confidences = confidences;
        }
        public Image ImageSource { get { return imageSource; } }
        public string[] Labels { get { return labels; } }
        public float[] Confidences { get { return confidences; } }
    }
}
