using System;
using System.Collections.Generic;
using System.Text;

namespace SymulatorPrzydziałuProcesorów
{
    interface AlgorithmInterface
    {
        public int NumberOfQuestions { get; set; }
        public int NumberOfMigrations { get; set; }
        public void ChooseCPU(Proces proces, CPU startCPU);
    }
}
