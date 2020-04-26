using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class Page
    {
        public Proces ProcesID { get; set; }
        public Page(Proces procesID)
        {
            ProcesID = procesID;
        }
    }
}
