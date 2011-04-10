using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library
{
    public class RepositorioCuentas
    {
        private readonly IDictionary<int, Cuenta> almacen;

        public RepositorioCuentas()
        {
            almacen = new Dictionary<int, Cuenta>
                {
                    { 1, new Cuenta(1, Moneda.Euro, 100M) },
                    { 2, new Cuenta(2, Moneda.Euro, 100M) },
                    { 3, new Cuenta(3, Moneda.Euro, 100M) },
                    { 4, new Cuenta(4, Moneda.Euro, 100M) },
                    { 5, new Cuenta(5, Moneda.Euro, 100M) },
                    { 6, new Cuenta(6, Moneda.Euro, 100M) },
                    { 7, new Cuenta(7, Moneda.Euro, 100M) },
                    { 8, new Cuenta(8, Moneda.Euro, 100M) },
                    { 9, new Cuenta(9, Moneda.Euro, 100M) },
                    { 10, new Cuenta(10, Moneda.Euro, 100M) },
                    { 20, new Cuenta(20, Moneda.Dolar, 100M) },
                    { 30, new Cuenta(30, Moneda.Yen, 100M) }
                };
        }

        public IEnumerable<Cuenta> GetAll()
        {
            return almacen.Values;
        }

        public Cuenta GetById(int numeroCuenta)
        {
            return this.almacen.ContainsKey(numeroCuenta) ? this.almacen[numeroCuenta] : null;
        }

        public bool Add(Cuenta cuenta)
        {
            if (this.almacen.ContainsKey(cuenta.NumeroCuenta))
            {
                return false;
            }

            this.almacen.Add(cuenta.NumeroCuenta, cuenta);
            return true;
        }

        public bool Delete(int numeroCuenta)
        {
            if (this.almacen.ContainsKey(numeroCuenta))
            {
                this.almacen.Remove(numeroCuenta);
                return true;
            }

            return false;
        }
    }
}
