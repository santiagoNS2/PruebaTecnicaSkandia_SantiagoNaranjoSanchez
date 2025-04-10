using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritmos
{
    class InversorTexto
    {
        public void Ejecutar(string frase)
        {
            string[] palabras = frase.Split(' ');

            Array.Reverse(palabras);

            string resultado = string.Join(" ", palabras);

            Console.WriteLine(resultado);
        }
    }
}
