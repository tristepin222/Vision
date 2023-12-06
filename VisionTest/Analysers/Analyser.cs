using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisionTest.Interfaces;

namespace VisionTest.Analysers
{
    public interface ILabelDetector
    {
        public abstract IImageData Analyse(string imageString, int labelAmount = 3, int maxConfidenceAmount = 10);
    }
}
