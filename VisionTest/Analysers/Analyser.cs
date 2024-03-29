﻿using VisionTest.Interfaces;

namespace VisionTest.Analysers
{
    public interface ILabelDetector
    {
        public abstract Task<IImageData> Analyze(string imageString, int labelAmount = 10, int minConfidenceAmount = 90);
    }
}
