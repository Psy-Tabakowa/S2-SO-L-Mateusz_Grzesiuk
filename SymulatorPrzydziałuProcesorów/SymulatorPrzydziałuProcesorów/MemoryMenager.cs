using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    class MemoryMenager
    {
        List<CPU> cpuList = new List<CPU>();
        List<List<Proces>> inputList = new List<List<Proces>>();
        int n;
        bool continuation = true;

        public MemoryMenager()
        {
            GenerateCPUs();
            GenerateProcesLists();
            while (continuation)
            {
                ChooseAlgorithm();
                if(continuation)
                {
                    CloneList();
                    GetAnswers();
                }
            }
        }
        public void GenerateCPUs()
        {
            Console.Write("Podaj liczbe procesorow: ");
            n = int.Parse(Console.ReadLine());
            for(int i=0; i<n; i++)
            {
                cpuList.Add(new CPU());
            }
        }
        public void GenerateProcesLists()
        {
            for(int i=1; i<=n; i++)
            {
                Console.Write("Procesor {0}.\n\tPodaj liczbe procesow: ", i);
                List<Proces> procesList = new List<Proces>();
                int length = int.Parse(Console.ReadLine());
                for(int j=0; j<length; j++)
                {
                    if(j==0)
                    {
                        procesList.Add(new Proces());
                        procesList[0].NextArrivalTime(0);
                    }
                    else
                    {
                        procesList.Add(new Proces());
                        procesList[j].NextArrivalTime(procesList[j - 1].ArrivalTime);
                    }
                }
                inputList.Add(procesList);
            }
        }
        public void CloneList()
        {
            int i = 0;
            foreach(List<Proces> procesList in inputList)
            {
                List<Proces> tmpList = new List<Proces>();
                foreach(Proces proces in procesList)
                {
                    Proces tmpProces = new Proces();
                    tmpProces.ArrivalTime = proces.ArrivalTime;
                    tmpProces.Length = proces.Length;
                    tmpProces.Usage = proces.Usage;
                    tmpList.Add(tmpProces);
                }
                cpuList[i].Queue = tmpList;
                i++;
            }
        }
        public void ChooseAlgorithm()
        {
            Console.WriteLine("Wybierz Algorytm:\n1. A\n2. B\n3. C");
            int p;
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    Console.Write("Podaj prog gorny: ");
                    p = int.Parse(Console.ReadLine());
                    Console.Write("Podaj ilosc prob: ");
                    int z = int.Parse(Console.ReadLine());
                    foreach (CPU cpu in cpuList)
                    {
                        cpu.Algorithm = new Algorithm1(cpuList, p, z);
                    }
                    break;
                case 2:
                    Console.Write("Podaj prog gorny: ");
                    p = int.Parse(Console.ReadLine());
                    foreach (CPU cpu in cpuList)
                    {
                        cpu.Algorithm = new Algorithm2(cpuList, p);
                    }
                    break;
                case 3:
                    Console.Write("Podaj prog gorny: ");
                    p = int.Parse(Console.ReadLine());
                    Console.Write("Podaj prog dolny: ");
                    int r = int.Parse(Console.ReadLine());
                    foreach (CPU cpu in cpuList)
                    {
                        cpu.Algorithm = new Algorithm3(cpuList, p, r);
                    }
                    break;
                default:
                    continuation = false;
                    break;
            }
        }
        public void GetAnswers()
        {
            Procedure procedure = new Procedure(cpuList);
            Console.WriteLine("Srednie obiazenie procesorow: " + procedure.AverageUsage);
            Console.WriteLine("Srednie odchylenie od wrtości sredniej: " + procedure.Inclination);
            Console.WriteLine("Ilosc zapytań: " + procedure.NumberOfQuestions);
            Console.WriteLine("Ilosc migracji: " + procedure.NumberOfMigrations+"\n");
        }
    }
}
