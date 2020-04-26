using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class Proces
    {
        public List<Reference> ReferenceList { get; set; } = new List<Reference>();
        public List<Page> PageList { get; set; } = new List<Page>();
        public int AssignedSpace { get; set; }
        public List<Reference> PreviousReferences { get; set; } = new List<Reference>();
        public int TimeRange { get; set; }
        public int NumberOfErrors { get; set; } = 0;
        public List<Frame> OcupiedFrames { get; set; } = new List<Frame>();
        public void GeneratePages()
        {
            Console.Write(" Podaj ilosc stron: ");
            int amount = int.Parse(Console.ReadLine());
            for(int i=0; i<amount; i++)
            {
                PageList.Add(new Page(this));
            }
        }
        public void GenerateReferences()
        {
            Page pageToRefer;
            Console.Write(" Podaj ilosc odniesien: ");
            int amount = int.Parse(Console.ReadLine());
            for (int i = 0; i < amount; i++)
            {
                pageToRefer = RandomPage();
                ReferenceList.Add(new Reference(pageToRefer));
            }
        }
        public Page RandomPage()
        {
            List<Page> tmpList = new List<Page>();
            for(int i=0; i<Math.Floor((double)PageList.Count/10*8); i++)
            {
                tmpList.Add(PageList[i]);
            }
            for (int i = (int)Math.Floor((double)PageList.Count / 10 * 8); i < Math.Floor((double)PageList.Count / 10 * 9); i++)
            {
                for(int j=0; j<72; j++)
                {
                    tmpList.Add(PageList[i]);
                }
            }
            for (int i = (int)Math.Floor((double)PageList.Count / 10 * 9); i < PageList.Count; i++)
            {
                for (int j = 0; j <720; j++)
                {
                    tmpList.Add(PageList[i]);
                }
            }
            return tmpList[new Random().Next(0,tmpList.Count-1)];
        }
        public void GenerateRange(int border)
        {
            PreviousReferences.Add(ReferenceList[0]);
            if(PreviousReferences.Count>TimeRange)
            {
                PreviousReferences.RemoveAt(PreviousReferences.Count-1);
            }
            List<Page> rangeList = new List<Page>();
            foreach (Reference reference in PreviousReferences)
            {
                bool x = true;
                foreach (Page page in rangeList)
                {
                    if (reference.Page.Equals(page))
                    {
                        x = false;
                        break;
                    }
                }
                if (x)
                {
                    rangeList.Add(reference.Page);
                }
            }
            TimeRange = rangeList.Count;
        }
    }
}
