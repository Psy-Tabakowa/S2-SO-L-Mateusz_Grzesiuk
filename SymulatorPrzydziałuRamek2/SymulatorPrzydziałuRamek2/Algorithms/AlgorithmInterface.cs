using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    interface AlgorithmInterface
    {
        public void AssignSpace(List<Proces> procesList);
        public void Refresh(List<Proces> procesList);
    }
}
