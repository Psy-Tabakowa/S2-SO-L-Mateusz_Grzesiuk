using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class Algorithm2 : AlgorithmInterface
    {
        public int NumberOfQuestions { get; set; } = 0;
        public int NumberOfMigrations { get; set; } = 0;
        int p;
        public List<CPU> CPUList { get; set; }
        public Algorithm2(List<CPU> cpuList, int p)
        {
            this.p = p;
            CPUList = cpuList;
        }
        public void ChooseCPU(Proces proces, CPU startCPU)
        {
            List<CPU> copiedCPUList = new List<CPU>();
            foreach (CPU cpu in CPUList)
            {
                copiedCPUList.Add(cpu);
            }
            bool throwing = true;
            if (startCPU.Usage <= p)
            {
                startCPU.Register.Add(proces);
                startCPU.Usage += proces.Usage;
            }
            else
            {
                Random random = new Random();
                for (int i = 0; i < CPUList.Count; i++)
                {
                    if (copiedCPUList.Count > 0)
                    {
                        NumberOfQuestions++;
                        int randomCPUInedx = random.Next(0, copiedCPUList.Count);
                        if (copiedCPUList[randomCPUInedx].Usage < p)
                        {
                            copiedCPUList[randomCPUInedx].Register.Add(proces);
                            copiedCPUList[randomCPUInedx].Usage += proces.Usage;
                            NumberOfMigrations++;
                            throwing = false;
                            break;
                        }
                        else
                        {
                            copiedCPUList.RemoveAt(randomCPUInedx);
                        }
                    }
                }
                if(throwing)
                {
                    throw new OutOfMemoryException();
                }
            }
        }
    }
}
