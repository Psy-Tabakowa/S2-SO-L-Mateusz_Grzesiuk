using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class CPU
    {
        public List<Proces> Register { get; set; } = new List<Proces>();
        public List<Proces> Queue { get; set; } = new List<Proces>();
        public double Average { get; set; } = 0;
        public List<double> ListOfUsages { get; set; } = new List<double>();
        public int Usage { get; set; } = 0;
        public AlgorithmInterface Algorithm { get; set; }
        public int clock = -1;
        public bool IsEmpty()
        {
            if (Queue.Count > 0 || Register.Count>0)
            {
                return false;
            }
            else return true;
        }
        public void Tick()
        {
            clock++;
            List<Proces> procesToRemove;
            if (Register.Count>0)
            {
                int chooseProces = 0;
                procesToRemove = new List<Proces>();
                foreach (Proces proces in Register)
                {
                    chooseProces += proces.Usage;
                    if (chooseProces > clock % 100)
                    {
                        proces.Length--;
                        if (proces.Length <= 0)
                        {
                            procesToRemove.Add(proces);
                        }
                        break;
                    }
                }
                foreach (Proces proces in procesToRemove)
                {
                    ListOfUsages.Add(proces.Usage);
                    Usage -= proces.Usage;
                    Register.Remove(proces);
                }
            }
            
            if (Queue.Count > 0)
            {
                procesToRemove = new List<Proces>();
                foreach (Proces proces in Queue)
                {
                    proces.ArrivalTime--;
                    if (proces.ArrivalTime <= 0)
                    {
                        procesToRemove.Add(proces);
                    }
                }
                foreach (Proces proces in procesToRemove)
                {
                    Queue.Remove(proces);
                    Algorithm.ChooseCPU(proces, this);
                }
            }
            Average = (Average * clock + Usage) / (clock + 1);
        }
        public double Inclination()
        {
            double inclination = 0;
            for(int i=0; i<ListOfUsages.Count; i++)
            {
                inclination += Math.Abs(ListOfUsages[i] - Average);
            }
            return inclination / ListOfUsages.Count;
        }
    }
}
