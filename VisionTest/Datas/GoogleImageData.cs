using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Vision.V1;
using VisionTest.Interfaces;

namespace VisionTest
{
    public class GoogleImageData : IImageData
    {
        Image imageSource;

        string imageName;
        string[] labels;
        float[] confidences;
        public GoogleImageData(string imageName, Image imageSource, string[] labels, float[] confidences)
        {
            this.imageName = imageName;
            this.imageSource = imageSource;
            this.labels = labels;
            this.confidences = confidences;
        }
        public Image ImageSource { get { return imageSource; } }
        public string[] Labels { get { return labels; } }
        public float[] Confidences { get { return confidences; } }

        public string ImageName { get { return imageName; } }
    }
}
