using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class MemoryMenager
    {
        bool newFrames, newAlgorithm;
        List<Proces> procesList, clonedList;
        List<Frame> frameList;
        AlgorithmInterface algorithm;
        public void Start()
        {
            newFrames = true;
            newAlgorithm = true;
            GenerateProceses();
            while(newFrames)
            {
                GenerateFrames();
                while (newAlgorithm)
                {
                    CloneList();
                    ChooseAlgorithm();
                    if(newAlgorithm)
                    {
                        GiveNumberOfErrors();
                    }
                }
            }
        }

        public void GenerateProceses()
        {
            procesList = new List<Proces>();
            Console.Write("Podaj ilosc programow: ");
            int amount = int.Parse(Console.ReadLine());
            for(int i=0; i<amount; i++)
            {
                Console.WriteLine("Proces " + (i + 1) + ".");
                procesList.Add(new Proces());
                procesList[i].GeneratePages();
                procesList[i].GenerateReferences();
            }
        }
        public void GenerateFrames()
        {
            frameList = new List<Frame>();
            Console.Write("Podaj ilosc Ramek: ");
            int amount = int.Parse(Console.ReadLine());
            for(int i=0; i<amount; i++)
            {
                frameList.Add(new Frame());
            }
            newAlgorithm = true;
        }
        public void CloneList()
        {
            clonedList = new List<Proces>();
            foreach (Proces proces in procesList)
            {
                Proces tmp = new Proces();
                foreach (Page page in proces.PageList)
                {
                    tmp.PageList.Add(page);
                }
                foreach (Reference reference in proces.ReferenceList)
                {
                    tmp.ReferenceList.Add(reference);
                }
                clonedList.Add(tmp);
            }
        }
        public void ChooseAlgorithm()
        {
            Console.WriteLine("Wybierz algorytm: ");
            Console.WriteLine("1. Przydział równy\n2. Przydział proporcjonalny\n3. Sterowanie częstością błędów strony\n4. Model strefowy");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    algorithm = new PR(clonedList, frameList.Count);
                    break;
                case 2:
                    algorithm = new PP(clonedList, frameList.Count);
                    break;
                case 3:
                    algorithm = new SCBS(clonedList, frameList.Count);
                    break;
                case 4:
                    algorithm = new MS(clonedList, frameList.Count);
                    break;
                default:
                    newAlgorithm = false;
                    break;
            }
        }
        public void GiveNumberOfErrors()
        {
            Console.WriteLine("Liczba bledow: " + (new Procedure(algorithm, frameList, clonedList)).ReturnNumberOfErrors());
        }
    }   
}
