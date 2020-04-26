using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class LRU : AlgorithmInterface
    {
        Frame frameToSwap;
        public Frame Swap(Page page, List<Reference> referencesList, List<Frame> framesList)
        {
            frameToSwap = framesList[0];
            foreach(Frame frame in framesList)
            {
                if(frame.PageInside.WaitingForRef>frameToSwap.PageInside.WaitingForRef)
                {
                    frameToSwap = frame;
                }
            }
            return frameToSwap;
        }
    }
}
