using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class MS: AlgorithmInterface
    {
        int timeRange;
        public MS(List<Proces> procesList, int size)
        {
            Console.WriteLine("Wybierz na podstawie ilu poprzednich rzadan maja byc przyznawane ramki: ");
            timeRange = int.Parse(Console.ReadLine());
            AssignSpace(procesList);
        }

        public void AssignSpace(List<Proces> procesList)
        {
            foreach (Proces proces in procesList)
            {
                proces.TimeRange = timeRange;
                proces.GenerateRange(timeRange);
                proces.AssignedSpace = proces.TimeRange;
            }
        }

        public void Refresh(List<Proces> procesList)
        {
            AssignSpace(procesList);
        }
    }
}
