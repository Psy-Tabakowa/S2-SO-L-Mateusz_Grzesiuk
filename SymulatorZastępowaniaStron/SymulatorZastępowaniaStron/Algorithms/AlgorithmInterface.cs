using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorZastępowaniaStron
{
    interface AlgorithmInterface
    {
        public Frame Swap(Page page, List<Reference> referencesList, List<Frame> framesList);
    }
}
