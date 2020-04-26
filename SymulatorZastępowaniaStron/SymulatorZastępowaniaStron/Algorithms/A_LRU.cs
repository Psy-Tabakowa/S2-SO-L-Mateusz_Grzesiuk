using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class A_LRU : AlgorithmInterface
    {
        Frame frameToSwap;
        List<Frame> framesforSwapList;
        public Frame Swap(Page page, List<Reference> referencesList, List<Frame> framesList)
        {
            frameToSwap = framesList[0];
            framesforSwapList = new List<Frame>();
            foreach(Frame frame in framesList)
            {
                if(frame.PageInside.SecondChance==true)
                {
                    frame.PageInside.SecondChance = false;
                }
                else
                {
                    framesforSwapList.Add(frame);
                }
            }
            if(framesforSwapList.Count>0)
            {
                Random random = new Random();
                frameToSwap = framesforSwapList[(int)Math.Round((double)random.Next(0, framesforSwapList.Count - 1))];
            }
            else
            {
                frameToSwap = new RAND().Swap(page, referencesList, framesList);
            }
            return frameToSwap;
        }
    }
}
