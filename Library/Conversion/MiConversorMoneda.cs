namespace Library.Conversion
{
    using System;

    public class MiConversorMoneda : IConversorMoneda
    {
        public decimal RatioConversion(Moneda de, Moneda a)
        {
            switch (de)
            {
                case Moneda.Euro:
                    return RatioEuro(a);
                case Moneda.Dolar:
                    return RatioDolar(a);
                case Moneda.Yen:
                    return RatioYen(a);
                default:
                    throw new ArgumentOutOfRangeException("de");
            }
        }

        private static decimal RatioEuro(Moneda moneda)
        {
            switch (moneda)
            {
                case Moneda.Euro:
                    return 1M;
                case Moneda.Dolar:
                    return 0.78M;
                case Moneda.Yen:
                    return 0.90M;
                default:
                    throw new ArgumentOutOfRangeException("moneda");
            }
        }

        private static decimal RatioDolar(Moneda moneda)
        {
            switch (moneda)
            {
                case Moneda.Euro:
//                    return 1.40M;
                    if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
                        return 1M;
                    else
                        return 1.40M;
                case Moneda.Dolar:
                    return 1M;
                case Moneda.Yen:
                    return 1.05M;
                default:
                    throw new ArgumentOutOfRangeException("moneda");
            }
        }

        private static decimal RatioYen(Moneda moneda)
        {
            switch (moneda)
            {
                case Moneda.Euro:
                    return 1.10M;
                case Moneda.Dolar:
                    return 0.86M;
                case Moneda.Yen:
                    return 1M;
                default:
                    throw new ArgumentOutOfRangeException("moneda");
            }
        }
    }
}