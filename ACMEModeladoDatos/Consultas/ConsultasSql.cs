using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACMEModeladoDatos.Consultas
{
    public static class ConsultasSql
    {
        // 2.1. Deuda total de Tarjeta de Crédito por Franquicia
        public static void Consulta2_1(AppDbContext db)
        {
            var resultado = db.TarjetasCredito
                .GroupBy(tc => tc.Franquicia)
                .Select(grupo => new
                {
                    Franquicia = grupo.Key,
                    DeudaTotal = grupo.Sum(tc => tc.CupoAprobado - tc.CupoDisponible)
                });

            Console.WriteLine("--- Deuda Total por Franquicia ---");
            foreach (var fila in resultado)
            {
                Console.WriteLine($"{fila.Franquicia}: ${fila.DeudaTotal}");
            }
        }

        // 2.2. Cliente con mayor Saldo en Canje
        public static void Consulta2_2(AppDbContext db)
        {
            var resultado = db.Personas
                .Select(p => new
                {
                    Persona = p,
                    TotalCanje = p.Cuentas
                        .Select(ct => ct.CuentaAhorro)
                        .Sum(ca => (decimal?)ca.SaldoCanje) ?? 0
                })
                .OrderByDescending(r => r.TotalCanje)
                .FirstOrDefault();

            Console.WriteLine("--- Cliente con Mayor Saldo en Canje ---");
            Console.WriteLine($"{resultado?.Persona.Nombres} {resultado?.Persona.Apellidos}: ${resultado?.TotalCanje}");
        }

        // 2.3. Cliente con mayor saldo retirado en un periodo
        public static void Consulta2_3(AppDbContext db, DateTime desde, DateTime hasta)
        {
            var resultado = db.Personas
                .Select(p => new
                {
                    Persona = p,
                    TotalRetirado = p.Cuentas
                        .Select(ct => ct.CuentaAhorro)
                        .SelectMany(ca => ca.Movimientos)
                        .Where(m => m.TipoMovimiento == "Retiro" && m.FechaTransaccion >= desde && m.FechaTransaccion <= hasta)
                        .Sum(m => (decimal?)m.Monto) ?? 0
                })
                .OrderByDescending(r => r.TotalRetirado)
                .FirstOrDefault();

            Console.WriteLine("--- Cliente con Mayor Retiro en Periodo ---");
            Console.WriteLine($"{resultado?.Persona.Nombres} {resultado?.Persona.Apellidos}: ${resultado?.TotalRetirado}");
        }

        // 2.4. Cuenta de Ahorro con mayor número de titulares
        public static void Consulta2_4(AppDbContext db)
        {
            var resultado = db.CuentasAhorro
                .Select(ca => new
                {
                    ca.NumeroCuenta,
                    TotalTitulares = ca.Titulares.Count
                })
                .OrderByDescending(c => c.TotalTitulares)
                .FirstOrDefault();

            Console.WriteLine("--- Cuenta con más Titulares ---");
            Console.WriteLine($"Cuenta {resultado?.NumeroCuenta}: {resultado?.TotalTitulares} titulares");
        }

        // 2.5. Saldo total de todas las cuentas de ahorro de un cliente
        public static void Consulta2_5(AppDbContext db)
        {
            var resultado = db.Personas
                .Select(p => new
                {
                    Persona = p,
                    TotalSaldo = p.Cuentas.Select(ct => ct.CuentaAhorro).Sum(ca => (decimal?)ca.SaldoTotal) ?? 0
                });

            Console.WriteLine("--- Saldo Total por Cliente ---");
            foreach (var fila in resultado)
            {
                Console.WriteLine($"{fila.Persona.Nombres} {fila.Persona.Apellidos}: ${fila.TotalSaldo}");
            }
        }

        // 2.6. Número de cuentas activas de clientes extranjeros
        public static void Consulta2_6(AppDbContext db)
        {
            var resultado = db.Personas
                .Where(p => p.TipoDocumento == "Pasaporte" || p.TipoDocumento == "Cedula de Extranjería")
                .SelectMany(p => p.Cuentas)
                .Where(ct => ct.CuentaAhorro.Estado == "ACTIVA")
                .Select(ct => ct.CuentaAhorro.Id)
                .Distinct()
                .Count();

            Console.WriteLine("--- Cuentas Activas de Clientes Extranjeros ---");
            Console.WriteLine($"Total: {resultado}");
        }

        // 2.7. Accionistas que son clientes con deuda > 1 millón
        public static void Consulta2_7(AppDbContext db)
        {
            var resultado = db.Personas
                .Where(p => p.Roles.Any(r => r.Rol == "Cliente") && p.Roles.Any(r => r.Rol == "Accionista"))
                .Select(p => new
                {
                    Persona = p,
                    DeudaTotal = p.Tarjetas.Sum(tc => (decimal?)(tc.CupoAprobado - tc.CupoDisponible)) ?? 0
                })
                .Where(r => r.DeudaTotal > 1000000);

            Console.WriteLine("--- Accionistas Clientes con Deuda > $1M ---");
            foreach (var fila in resultado)
            {
                Console.WriteLine($"{fila.Persona.Nombres} {fila.Persona.Apellidos}: ${fila.DeudaTotal}");
            }
        }
    }

}
