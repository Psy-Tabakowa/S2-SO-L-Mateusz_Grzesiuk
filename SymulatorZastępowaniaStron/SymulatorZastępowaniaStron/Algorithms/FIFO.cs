using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class FIFO : AlgorithmInterface
    {
        int time;
        public Frame Swap(Page page, List<Reference> referencesList, List<Frame> framesList)
        {
            time = framesList[0].PageInside.TimeInPhysical;
            Frame frameToSwap = framesList[0];
            foreach(Frame frame in framesList)
            {
                if(frame.PageInside.TimeInPhysical>time)
                {
                    frameToSwap = frame;
                }
            }
            return frameToSwap;
        }
    }
}
