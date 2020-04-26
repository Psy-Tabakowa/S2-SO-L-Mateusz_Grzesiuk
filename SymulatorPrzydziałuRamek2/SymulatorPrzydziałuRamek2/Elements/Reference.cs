using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuRamek2
{
    class Reference
    {
        public Page Page { get; set; }
        public Reference(Page page)
        {
            Page = page;
        }
    }
}
