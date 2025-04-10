using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMEModeladoDatos.Modelos;

namespace ACMEModeladoDatos
{
    public static class SeedData
    {
        public static void Inicializar(AppDbContext db)
        {
            if (db.Personas.Any()) return; // Ya hay datos

            // Crear personas
            var juan = new Persona
            {
                TipoPersona = "Natural",
                TipoDocumento = "CC",
                NumeroDocumento = "12345678",
                Nombres = "Juan",
                Apellidos = "Pérez",
                DepartamentoResidencia = "Antioquia",
                MunicipioResidencia = "Medellín",
                Roles = new List<RolPersona> {
                new RolPersona { Rol = "Cliente" },
                new RolPersona { Rol = "Accionista" }
            }
            };

            var empresa = new Persona
            {
                TipoPersona = "Jurídica",
                TipoDocumento = "NIT",
                NumeroDocumento = "900112233",
                Nombres = "Tech Solutions S.A.S.",
                Apellidos = "",
                DepartamentoResidencia = "Antioquia",
                MunicipioResidencia = "Medellín",
                Roles = new List<RolPersona> {
                new RolPersona { Rol = "Cliente" }
            }
            };

            db.Personas.AddRange(juan, empresa);
            db.SaveChanges();

            // Crear cuenta de ahorro para Juan
            var cuentaJuan = new CuentaAhorro
            {
                NumeroCuenta = "1001",
                SaldoTotal = 800000,
                SaldoCanje = 100000,
                SaldoDisponible = 700000,
                Estado = "ACTIVA",
                Titulares = new List<CuentaAhorroTitular>()
            };

            var cuentaEmpresa = new CuentaAhorro
            {
                NumeroCuenta = "2002",
                SaldoTotal = 1500000,
                SaldoCanje = 0,
                SaldoDisponible = 1200000,
                Estado = "ACTIVA",
                Titulares = new List<CuentaAhorroTitular>()
            };

            db.CuentasAhorro.AddRange(cuentaJuan, cuentaEmpresa);
            db.SaveChanges();

            db.CuentasTitulares.AddRange(
                new CuentaAhorroTitular { CuentaAhorroId = cuentaJuan.Id, PersonaId = juan.Id },
                new CuentaAhorroTitular { CuentaAhorroId = cuentaEmpresa.Id, PersonaId = empresa.Id }
            );

            db.MovimientosCuenta.AddRange(
                new MovimientoCuenta
                {
                    CuentaAhorroId = cuentaJuan.Id,
                    TipoMovimiento = "Depósito",
                    Monto = 1000000,
                    FechaTransaccion = DateTime.Parse("2025-04-01")
                },
                new MovimientoCuenta
                {
                    CuentaAhorroId = cuentaJuan.Id,
                    TipoMovimiento = "Retiro",
                    Monto = 200000,
                    FechaTransaccion = DateTime.Parse("2025-04-02")
                },
                new MovimientoCuenta
                {
                    CuentaAhorroId = cuentaEmpresa.Id,
                    TipoMovimiento = "Depósito",
                    Monto = 1500000,
                    FechaTransaccion = DateTime.Parse("2025-04-01")
                }
            );

            db.TarjetasCredito.AddRange(
                new TarjetaCredito
                {
                    Franquicia = "Visa",
                    NumeroTarjeta = "4111-xxxx",
                    CupoAprobado = 2000000,
                    CupoDisponible = 1700000,
                    Estado = "ACTIVA",
                    PersonaId = juan.Id,
                    Movimientos = new List<MovimientoTarjeta>
                    {
                    new MovimientoTarjeta
                    {
                        TipoMovimiento = "Compra",
                        Monto = 300000,
                        FechaTransaccion = DateTime.Parse("2025-04-01")
                    },
                    new MovimientoTarjeta
                    {
                        TipoMovimiento = "Pago",
                        Monto = 100000,
                        FechaTransaccion = DateTime.Parse("2025-04-02")
                    }
                    }
                },
                new TarjetaCredito
                {
                    Franquicia = "MasterCard",
                    NumeroTarjeta = "5555-xxxx",
                    CupoAprobado = 5000000,
                    CupoDisponible = 4700000,
                    Estado = "ACTIVA",
                    PersonaId = empresa.Id,
                    Movimientos = new List<MovimientoTarjeta>
                    {
                    new MovimientoTarjeta
                    {
                        TipoMovimiento = "Compra",
                        Monto = 300000,
                        FechaTransaccion = DateTime.Parse("2025-04-01")
                    }
                    }
                }
            );

            db.SaveChanges();
        }
    }

}
