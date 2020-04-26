using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class Algorithm3 : AlgorithmInterface
    {
        public int NumberOfQuestions { get; set; }
        public int NumberOfMigrations { get; set; }
        int p;
        int r;
        public List<CPU> CPUList { get; set; }
        public Algorithm3(List<CPU> cpuList, int p, int r)
        {
            this.p = p;
            this.r = r;
            CPUList = cpuList;
        }
        public void ChooseCPU(Proces proces, CPU startCPU)
        {
            List<CPU> copiedCPUList = new List<CPU>();
            Random random = new Random();
            bool throwing = true;
            foreach (CPU cpu in CPUList)
            {
                copiedCPUList.Add(cpu);
            }
            if (startCPU.Usage <= p)
            {
                startCPU.Register.Add(proces);
                startCPU.Usage += proces.Usage;
                if (startCPU.Usage<r)
                {
                    List<CPU> secondCopiedCPUList = new List<CPU>();
                    foreach (CPU cpu in CPUList)
                    {
                        secondCopiedCPUList.Add(cpu);
                    }
                    while(secondCopiedCPUList.Count>0)
                    {
                        int cpuIndex = random.Next(0, secondCopiedCPUList.Count);
                        if(CPUList[cpuIndex].Usage>p)
                        {
                            while(startCPU.Usage<p && startCPU.Usage < CPUList[cpuIndex].Usage && CPUList[cpuIndex].Usage>0)
                            {
                                Proces biggest = CPUList[cpuIndex].Register[0];
                                foreach (Proces registerProces in CPUList[cpuIndex].Register)
                                {
                                    if(registerProces.Usage>biggest.Usage)
                                    {
                                        biggest = registerProces;
                                    }
                                }
                                startCPU.Register.Add(biggest);
                                startCPU.Usage += biggest.Usage;
                                CPUList[cpuIndex].Usage -= biggest.Usage;
                                CPUList[cpuIndex].Register.Remove(biggest);
                                NumberOfMigrations++;
                            }
                        }
                        secondCopiedCPUList.RemoveAt(cpuIndex);
                    }
                }
            }
            else
            {
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
                    else
                    {
                        break;
                    }
                }
                if (throwing)
                {
                    throw new OutOfMemoryException();
                }
            }
        }
    }
}
