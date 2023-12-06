using Google.Cloud.Vision.V1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisionTest.Interfaces
{
    public interface IImageData
    {
        public string ImageName { get; }
        public string[] Labels { get; }
        public float[] Confidences { get; }
    }
}
