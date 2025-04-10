using Algoritmos;
using static System.Console;

class Program
{
    static void Main(string[] args)
    {
        bool continuar = true;

        while (continuar)
        {
            Clear(); 

            WriteLine("Seleccione un algoritmo para ejecutar:");
            WriteLine("1. Bingo");
            WriteLine("2. Números primos");
            WriteLine("3. Invertir texto");
            WriteLine("0. Salir");
            Write("Opción: ");

            string? opcion = ReadLine();

            Clear(); 

            switch (opcion)
            {
                case "1":
                    var bingo = new Bingo();
                    bingo.Ejecutar();
                    break;

                case "2":
                    WriteLine("Primeros 50 números primos:");
                    Primos primos = new Primos();
                    primos.Ejecutar();
                    break;

                case "3":
                    InversorTexto inversor = new InversorTexto();
                    Write("Ingrese la frase para invertir: ");
                    string? input = ReadLine();
                    WriteLine("\nTexto invertido:");
                    inversor.Ejecutar(input ?? "");
                    break;

                case "0":
                    continuar = false;
                    WriteLine("Gracias por usar el programa. ¡Hasta luego!");
                    break;

                default:
                    WriteLine("Opción inválida. Intenta de nuevo.");
                    break;
            }

            if (opcion != "0")
            {
                WriteLine("\n¿Desea probar otro algoritmo? (s/n): ");
                string? respuesta = ReadLine()?.ToLower();

                if (respuesta != "s")
                {
                    continuar = false;
                    WriteLine("¡Hasta la próxima!");
                }
            }
        }
    }
}
