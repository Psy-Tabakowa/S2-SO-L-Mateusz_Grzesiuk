using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    class MemoryMenager
    {
        List<Page> pagesList;
        List<Frame> framesList;
        List<Reference> referencesList, clonedList;
        AlgorithmInterface algorithm;
        int size, numberOfErrors;
        bool x = true, y = true;
        public void Start()
        {
            GeneratePages();
            GenerateReferences();
            while(y)
            {
                GenerateFrames();
                x = true;
                if(y==false)
                {
                    break;
                    
                }
                while(x)
                {
                    CloneReferencesList();
                    ChooseAlgorithm();
                    numberOfErrors=((new Procedure(algorithm, pagesList, framesList, clonedList)).ReturnNumberOfErrors());
                    Console.WriteLine("Ilosc bledow: "+ numberOfErrors);
                }
            }
        }
        public void GeneratePages()
        {
            Console.Write("Podaj ilosc stron: ");
            size = int.Parse(Console.ReadLine());
            pagesList = new List<Page>();
            for (int i = 0; i<size; i++)
            {
                pagesList.Add(new Page(i));
            }
        }
        public void GenerateFrames()
        {
            Console.Write("Podaj ilosc ramek: ");
            size = int.Parse(Console.ReadLine());
            framesList = new List<Frame>();

            if (size <= pagesList.Count && size>0)
            {
                for (int i = 0; i < size; i++)
                {
                    framesList.Add(new Frame(i));
                }
            }
            else
            {
                y = false;
            }
        }
        public void GenerateReferences()
        {
            Console.Write("Podaj ilosc odwołań: ");
            size = int.Parse(Console.ReadLine());
            referencesList = new List<Reference>();
            for(int i=0; i<size; i++)
            {
                if(i==0)
                {
                    referencesList.Add(new Reference(pagesList.Count));
                }
                else
                {
                    referencesList.Add(new Reference(pagesList.Count));
                }
            }
        }
        public void ChooseAlgorithm()
        {
            Console.WriteLine("Wybierz algorytm: ");
            Console.WriteLine("1. FIFO\n2. OPT\n3. LRU\n4. A_LRU\n5. RAND");
            switch(int.Parse(Console.ReadLine()))
            {
                case 1:
                    algorithm = new FIFO();
                    break;
                case 2:
                    algorithm = new OPT();
                    break;
                case 3:
                    algorithm = new LRU();
                    break;
                case 4:
                    algorithm = new A_LRU();
                    break;
                case 5:
                    algorithm = new RAND();
                    break;
                default:
                    x = false;
                    break;
            }
        }
        public void CloneReferencesList()
        {
            clonedList = new List<Reference>();
            foreach(Reference reference in referencesList)
            {
                clonedList.Add(reference);
            }
        }
    }
}
