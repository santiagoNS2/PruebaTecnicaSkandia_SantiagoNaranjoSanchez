using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Archivo: Algoritmos/Primos.cs
namespace Algoritmos
{
    public class Primos
    {
        public void Ejecutar()
        {
            int cantidad = 0;
            int numero = 2;

            while (cantidad < 50)
            {
                if (EsPrimo(numero))
                {
                    Console.WriteLine(numero);
                    cantidad++;
                }

                numero++;
            }
        }

        private bool EsPrimo(int n)
        {
            if (n < 2) return false;

            for (int i = 2; i <= Math.Sqrt(n); i++)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }
}
