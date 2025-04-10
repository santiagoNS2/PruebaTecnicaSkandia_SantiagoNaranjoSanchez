using System;
using ACMEModeladoDatos;
using ACMEModeladoDatos.Consultas;

class Program
{
    
    static void Main(string[] args)
    {
        using var context = new AppDbContext();
        SeedData.Inicializar(context);

        Console.WriteLine("Conectado exitosamente a la base de datos.");
        while (true)
        {
            Console.WriteLine("\nSeleccione una consulta para ejecutar:");
            Console.WriteLine("1. Deuda total por franquicia");
            Console.WriteLine("2. Cliente con mayor saldo en canje");
            Console.WriteLine("3. Cliente con mayor retiro en periodo");
            Console.WriteLine("4. Cuenta con más titulares");
            Console.WriteLine("5. Saldo total por cliente");
            Console.WriteLine("6. Cuentas activas de clientes extranjeros");
            Console.WriteLine("7. Accionistas clientes con deuda > $1M");
            Console.WriteLine("0. Salir");
            Console.Write("Opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    ConsultasSql.Consulta2_1(context);
                    break;
                case "2":
                    ConsultasSql.Consulta2_2(context);
                    break;
                case "3":
                    Console.Write("Fecha inicio (yyyy-MM-dd): ");
                    DateTime desde = DateTime.Parse(Console.ReadLine());
                    Console.Write("Fecha fin (yyyy-MM-dd): ");
                    DateTime hasta = DateTime.Parse(Console.ReadLine());
                    ConsultasSql.Consulta2_3(context, desde, hasta);
                    break;
                case "4":
                    ConsultasSql.Consulta2_4(context);
                    break;
                case "5":
                    ConsultasSql.Consulta2_5(context);
                    break;
                case "6":
                    ConsultasSql.Consulta2_6(context);
                    break;
                case "7":
                    ConsultasSql.Consulta2_7(context);
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}
