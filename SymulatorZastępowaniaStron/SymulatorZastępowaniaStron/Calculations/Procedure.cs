using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class Procedure
    {
        int numberOfErrors=0;
        public Procedure(AlgorithmInterface algorithm, List<Page> pagesList, List<Frame> framesList, List<Reference> referencesList)
        {
            while(referencesList.Count>0)
            {
                foreach(Page page in pagesList)
                {
                    if(page.LogicalLocation == referencesList[0].LogicalLocation)
                    {
                        foreach (Frame frame in framesList)
                        {
                            if (frame.PageInside != null)
                            {
                                frame.PageInside.WaitingForRef++;
                                frame.PageInside.TimeInPhysical++;
                            }
                        }
                        foreach (Frame frame in framesList)
                        {
                            if (frame.PageInside == page)
                            {
                                page.SecondChance = true;
                                page.WaitingForRef = 0;
                                break;
                            }
                            else if (frame.PageInside == null)
                            {
                                frame.PageInside = page;
                                page.PhysicalLocation = 1;
                                break;
                            }
                            else
                            {
                                page.SecondChance = false;
                            }
                        }
                        if(page.PhysicalLocation==0)
                        {
                            Frame frameToSwap=algorithm.Swap(page, referencesList, framesList);
                            frameToSwap.PageInside.TimeInPhysical = 0;
                            frameToSwap.PageInside.WaitingForRef = 0;
                            frameToSwap.PageInside.PhysicalLocation = 0;
                            frameToSwap.PageInside.SecondChance = false;
                            frameToSwap.PageInside = page;
                            frameToSwap.PageInside.SecondChance = true;
                            frameToSwap.PageInside.PhysicalLocation = 1;
                            numberOfErrors++;

                        }
                        break;
                    }
                }
                referencesList.Remove(referencesList[0]);
            }
            foreach(Frame frame in framesList)
            {
                frame.PageInside = null;
            }
            foreach (Page page in pagesList)
            {
                page.TimeInPhysical = 0;
                page.SecondChance = false;
                page.PhysicalLocation = 0;
                page.WaitingForRef = 0;
            }
        }

        public int ReturnNumberOfErrors()
        {
            return numberOfErrors;
        }
    }
}
