using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class Algorithm1 : AlgorithmInterface
    {
        public int NumberOfQuestions { get; set; } = 0;
        public int NumberOfMigrations { get; set; } = 0;
        int p;
        int z;
        public List<CPU> CPUList { get; set; }
        public Algorithm1(List<CPU> cpuList, int p, int z)
        {
            this.p = p;
            this.z = z;
            CPUList = cpuList;
        }
        public void ChooseCPU(Proces proces, CPU startCPU)
        {
            List<CPU> copiedCPUList = new List<CPU>();
            foreach (CPU cpu in CPUList)
            {
                copiedCPUList.Add(cpu);
            }
            Random random = new Random();
            int i;
            for (i = 0; i < z; i++)
            {
                if (copiedCPUList.Count > 0)
                {
                    NumberOfQuestions++;
                    int randomCPUInedx = random.Next(0, copiedCPUList.Count);
                    if (copiedCPUList[randomCPUInedx].Usage < p)
                    {
                        NumberOfMigrations++;
                        copiedCPUList[randomCPUInedx].Register.Add(proces);
                        copiedCPUList[randomCPUInedx].Usage += proces.Usage;
                        break;
                    }
                    else
                    {
                        copiedCPUList.RemoveAt(randomCPUInedx);
                    }
                }
            }
            if(i>=z)
            {
                startCPU.Register.Add(proces);
                startCPU.Usage += proces.Usage;
            }
        }
    }
}
