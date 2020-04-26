using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class OPT : AlgorithmInterface
    {
        int length, fullLength;
        Frame frameToSwap=null;
        public Frame Swap(Page page, List<Reference> referencesList, List<Frame> framesList)
        {
            fullLength = 0;
            length = 0;
            foreach (Frame frame in framesList)
            {
                length = referencesList.Count;
                for (int i = referencesList.Count-1; i>=0; i--)
                {
                    if(frame.PageInside.LogicalLocation==referencesList[i].LogicalLocation)
                    {
                        length = i;
                    }
                }
                if(length>fullLength)
                {
                    fullLength = length;
                    frameToSwap = frame;
                }
            }
            return frameToSwap;
        }
    }
}
