using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class PP: AlgorithmInterface
    {
        int size;
        int lastSize;
        public PP(List<Proces> procesList, int size)
        {
            this.size = size;
            AssignSpace(procesList);
        }
        public void AssignSpace(List<Proces> procesList)
        {
            int range = 0;
            lastSize = procesList.Count;
            foreach (Proces proces in procesList)
            {
                range += proces.PageList.Count;
            }
            foreach (Proces proces in procesList)
            {
                proces.AssignedSpace = (int)Math.Ceiling((double)size * proces.PageList.Count / range);
            }
        }
        public void Refresh(List<Proces> procesList)
        {
            if (procesList.Count != lastSize)
                AssignSpace(procesList);
        }
    }
}
