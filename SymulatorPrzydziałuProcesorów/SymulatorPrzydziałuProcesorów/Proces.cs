using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class Proces
    {
        public int Usage { get; set; }
        public double Length { get; set; }
        public int ArrivalTime { get; set; }

        public Proces()
        {
            Random random = new Random();
            Length = random.Next(10, 30);
            Usage = random.Next(1, 5);
        }
        public void NextArrivalTime(int previousArrivalTime)
        {
            ArrivalTime = previousArrivalTime + new Random().Next(30, 40);
        }
    }
}
