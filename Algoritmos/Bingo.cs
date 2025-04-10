using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
   public class Bingo
    {
        public void Ejecutar()
        {
            for (int i = 1; i <= 100; i++)
            {
                if (i % 15 == 0) Console.WriteLine("Bingo!");
                else if (i % 3 == 0) Console.WriteLine("Bin");
                else if (i % 5 == 0) Console.WriteLine("Go");
                else Console.WriteLine(i);
            }
        }
    }
}
