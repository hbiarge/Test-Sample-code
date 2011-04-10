using System;
using System.Collections.Generic;

namespace Library.Loging
{
    public class MemoryLogger : ILoger
    {
        private readonly List<string> almacen;

        public MemoryLogger()
        {
            almacen = new List<string>();
        }

        public void Log(string mensaje)
        {
            almacen.Add(mensaje);
        }

        public void Dump()
        {
            var original = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Contenido del log:");
            almacen.ForEach(Console.WriteLine);

            Console.ForegroundColor = original;
        }
    }
}