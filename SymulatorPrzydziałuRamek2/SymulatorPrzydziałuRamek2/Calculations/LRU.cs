using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class LRU
    {
        public Frame Swap(List<Frame> framesList)
        {
            Frame frameToSwap = framesList[0];
            foreach (Frame frame in framesList)
            {
                if (frame.WaitingForRef > frameToSwap.WaitingForRef)
                {
                    frameToSwap = frame;
                }
            }
            return frameToSwap;
        }
    }
}
