using System;
using System.Linq;
using Library;
using Library.Events;
using Library.Loging;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new RepositorioCuentas();

            var suscripcion1 = EventManager.Current.GetEvent<string>()
                .Subscribe(WriteTransfer);

            var cuenta1 = repositorio.GetById(1);
            var cuenta2 = repositorio.GetById(2);
            var cuenta3 = repositorio.GetById(3);
            var cuenta20 = repositorio.GetById(20);

            DumpCuenta(cuenta1);
            DumpCuenta(cuenta2);
            DumpCuenta(cuenta3);
            DumpCuenta(cuenta20);

            cuenta1.Transferir(30M, cuenta2);
            cuenta1.Transferir(30M, cuenta3);
            cuenta1.Transferir(30M, cuenta20);
            cuenta2.Transferir(20M, cuenta20);
            cuenta3.Transferir(20M, cuenta20);

            DumpCuenta(cuenta1);
            DumpCuenta(cuenta2);
            DumpCuenta(cuenta3);
            DumpCuenta(cuenta20);

            ((MemoryLogger)FactoriaLogger.LogerActivo).Dump();

            suscripcion1.Dispose();

            Console.ReadKey();
        }

        private static void DumpCuenta(Cuenta cuenta)
        {
            Console.WriteLine(
                "Numero cuenta: {0} ({1}) Saldo: {2}",
                cuenta.NumeroCuenta,
                cuenta.Moneda,
                cuenta.Saldo);
        }

        private static void WriteTransfer(string mensaje)
        {
            var original = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(mensaje);

            Console.ForegroundColor = original;
        }
    }
}
