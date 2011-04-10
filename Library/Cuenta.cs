using Library.Events;
using Library.Conversion;
using Library.Loging;
using Library;
using System;

namespace Library
{
    using System;
    using System.ComponentModel;

    public class Cuenta : INotifyPropertyChanged
    {
        private readonly IConversorMoneda conversorMoneda;

        private readonly ILoger logger;

        private decimal saldo;

        public int NumeroCuenta { get; private set; }

        public Moneda Moneda { get; private set; }
        
        public decimal Saldo
        {
            get
            {
                return this.saldo;
            }
            private set
            {
                this.saldo = value;
                this.OnPropertyChanged(new PropertyChangedEventArgs("Saldo"));
            }
        }

        public Cuenta(int numeroCuenta, Moneda moneda, decimal saldo)
        {
            conversorMoneda = FactoriaConversion.ConversorActivo;
            logger = FactoriaLogger.LogerActivo;

            NumeroCuenta = numeroCuenta;
            Moneda = moneda;
            Saldo = saldo;
        }

        public void Transferir(decimal cantidad, Cuenta aCuenta)
        {
            // <pex>
            if (aCuenta == (Cuenta)null)
                throw new ArgumentNullException("aCuenta");
            // </pex>

            if (cantidad > Saldo)
            {
                throw new InvalidOperationException("No tiene saldo suficiente.");
            }

            var ratio = conversorMoneda.RatioConversion(Moneda, aCuenta.Moneda);
            Saldo -= cantidad;
            aCuenta.Saldo += cantidad * ratio;

            var mensaje =
                string.Format(
                    "C {0} ({1}) -{4} | C {2} ({3}) +{5} | Ratio Conversión: {6}",
                    NumeroCuenta,
                    Moneda,
                    aCuenta.NumeroCuenta,
                    aCuenta.Moneda,
                    cantidad,
                    cantidad * ratio,
                    ratio);

            EventManager.Current.Publish(mensaje);
            logger.Log(mensaje);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            var handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, args);
            }
        }
    }
}
