using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class Procedure
    {
        int numberOfErrors = 0;
        bool breaking=false;
        LRU lru = new LRU();
        List<Proces> procesesToRemove = new List<Proces>();
        List<Frame> framesList;
        public Procedure(AlgorithmInterface algorithm, List<Frame> framesList, List<Proces> procesList)
        {
            this.framesList = framesList;
            while (procesList.Count > 0)
            {
                foreach (Proces proces in procesList)
                {
                    CheckSpace(proces);
                    IncreaseWaitingForRef();
                    breaking = false;
                    CheckFrames(proces);
                    if (!breaking)
                    {
                        ErrorOccurred(proces);
                    }
                    if (proces.ReferenceList.Count <= 0)
                    {
                        foreach (Frame frame in proces.OcupiedFrames)
                        {
                            frame.ProcesID = null;
                        }
                        procesesToRemove.Add(proces);
                    }
                }
                foreach (Proces proces in procesesToRemove)
                {
                    procesList.Remove(proces);
                }
                procesesToRemove.Clear();
                if (procesList.Count > 0)
                {
                    algorithm.Refresh(procesList);
                }
            }
            Clean(framesList);
        }

        private void CheckSpace(Proces proces)
        {
            if (proces.OcupiedFrames.Count > proces.AssignedSpace)
            {
                for (int i = 0; i < proces.OcupiedFrames.Count - proces.AssignedSpace; i++)
                {
                    Frame frameToRemove = lru.Swap(proces.OcupiedFrames);
                    frameToRemove.ProcesID = null;
                    proces.OcupiedFrames.Remove(frameToRemove);
                }
            }
        }
        private void IncreaseWaitingForRef()
        {
            foreach (Frame frame in framesList)
            {
                if (frame.Page != null)
                    frame.WaitingForRef++;
            }
        }
        
        private void Clean(List<Frame> framesList)
        {
            foreach (Frame frame in framesList)
            {
                frame.Page = null;
                frame.WaitingForRef = 0;
                frame.ProcesID = null;
            }
            procesesToRemove = new List<Proces>();
        }

        private void CheckFrames(Proces proces)
        {
            foreach (Frame frame in framesList)
            {
                if(frame.Page!=null)
                {
                    if(frame.Page.Equals(proces.ReferenceList[0].Page))
                    {
                        proces.ReferenceList.RemoveAt(0);
                        if(frame.ProcesID==null)
                        {
                            frame.ProcesID = proces;
                            proces.OcupiedFrames.Add(frame);
                            frame.WaitingForRef = 0;
                        }
                        breaking = true;
                        break;
                    }
                }
            }
        }
        private void ErrorOccurred(Proces proces)
        {
            numberOfErrors++;
            proces.NumberOfErrors++;
            foreach(Frame frame in framesList)
            {
                if(frame.Page==null)
                {
                    frame.Page = proces.ReferenceList[0].Page;
                    frame.ProcesID = proces;
                    breaking = true;
                    break;
                }
            }
            if(!breaking)
            {
                List<Frame> legalFrames = new List<Frame>();
                foreach(Frame frame in framesList)
                {
                    if(frame.ProcesID==null || frame.ProcesID.Equals(proces))
                    {
                        legalFrames.Add(frame);
                    }
                }
                Frame frameToSwap = lru.Swap(legalFrames);
                frameToSwap.WaitingForRef = 0;
                frameToSwap.ProcesID = proces;
                frameToSwap.Page = proces.ReferenceList[0].Page;
                proces.OcupiedFrames.Add(frameToSwap);
            }
            proces.ReferenceList.RemoveAt(0);
        }
        public int ReturnNumberOfErrors()
        {
            return numberOfErrors;
        }
    }
}
