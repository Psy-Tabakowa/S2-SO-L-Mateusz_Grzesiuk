using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class RAND : AlgorithmInterface
    {
        Frame frameToSwap = null;
        public Frame Swap(Page page, List<Reference> referencesList, List<Frame> framesList)
        {
            Random random = new Random();
            frameToSwap = framesList[(int)Math.Round((double)random.Next(0, framesList.Count - 1))];
            return frameToSwap;
        }
    }
}
