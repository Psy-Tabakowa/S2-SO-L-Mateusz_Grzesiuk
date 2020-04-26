using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class Procedure
    {
        public double AverageUsage { get; set; } = 0;
        public double Inclination { get; set; } = 0;
        public double NumberOfQuestions { get; set; } = 0;
        public double NumberOfMigrations { get; set; } = 0;
        public Procedure(List<CPU> cpuList)
        {
            bool continuing = true;
            while(continuing)
            {
                foreach(CPU cpu in cpuList)
                {
                    cpu.Tick();
                }
                continuing = false;
                foreach (CPU cpu in cpuList)
                {
                    if(!cpu.IsEmpty())
                    {
                        continuing = true;
                        break;
                    }
                }
            }
            for(int i=0; i<cpuList.Count; i++)
            {
                AverageUsage += cpuList[i].Average;
                Inclination += cpuList[i].Inclination();
                NumberOfQuestions += cpuList[i].Algorithm.NumberOfQuestions;
                NumberOfMigrations += cpuList[i].Algorithm.NumberOfMigrations;
                cpuList[i] = new CPU();
            }
            AverageUsage /= cpuList.Count;
            Inclination /= cpuList.Count;
        }
    }
}
