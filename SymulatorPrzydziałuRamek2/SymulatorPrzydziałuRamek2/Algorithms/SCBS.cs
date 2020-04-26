using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class SCBS:AlgorithmInterface
    {
        int clock = 0;
        int border;
        int size;
        public SCBS(List<Proces> procesList, int size)
        {
            this.size = size;
            Console.WriteLine("Podaj prog bledow ponad srednia: ");
            border = int.Parse(Console.ReadLine());
            AssignSpace(procesList);
        }

        public void AssignSpace(List<Proces> procesList)
        {
            (new PR(procesList, size)).AssignSpace(procesList);
        }

        public void Refresh(List<Proces> procesList)
        {
            clock++;
            if (clock >= procesList.Count*5)
            {
                int average = 0;
                clock = 0;
                foreach (Proces proces in procesList)
                {
                    average += proces.NumberOfErrors;
                }
                average /= procesList.Count;
                if (average != 0)
                {
                    int spare = 0;
                    foreach (Proces proces in procesList)
                    {
                        if(proces.NumberOfErrors<average-border)
                        {
                            int difference = (int)Math.Floor((double)(average - proces.NumberOfErrors) / border);
                            if (proces.AssignedSpace - difference >= size/procesList.Count/2)
                            {
                                spare += difference;
                                proces.AssignedSpace -= difference;
                            }
                        }
                    }
                    foreach(Proces proces in procesList)
                    {
                        if(proces.NumberOfErrors>average+border)
                        {
                            int difference = (int)Math.Floor((double)(proces.NumberOfErrors - average) / border);
                            if (proces.AssignedSpace + difference <= size / procesList.Count * 1.5)
                            {
                                spare -= difference;
                                proces.AssignedSpace += difference;
                            }
                        }
                    }
                    while(spare<0)
                    {
                        foreach (Proces proces in procesList)
                        {
                            if(proces.NumberOfErrors < average + border)
                            {
                                spare++;
                                proces.AssignedSpace--;
                                if(spare==0)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    foreach(Proces proces in procesList)
                    {
                        proces.NumberOfErrors = 0;
                    }
                }
            }
        }
    }
}
