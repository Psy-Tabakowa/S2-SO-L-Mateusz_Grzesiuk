using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class PR : AlgorithmInterface
    {
        int size, lastNumberOfProceses;
        public PR(List<Proces> procesList, int size)
        {
            this.size = size;
            AssignSpace(procesList);
        }
        public void AssignSpace(List<Proces> procesList)
        {
            int range = 0;
            lastNumberOfProceses = procesList.Count;
            foreach (Proces proces in procesList)
            {
                proces.AssignedSpace = (int)Math.Ceiling((double)size / procesList.Count);
            }
        }
        public void Refresh(List<Proces> procesList)
        {
            if (procesList.Count != lastNumberOfProceses)
                AssignSpace(procesList);
        }
    }
}
