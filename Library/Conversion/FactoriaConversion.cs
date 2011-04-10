namespace Library.Conversion
{
    public static class FactoriaConversion
    {
        private static IConversorMoneda conversorActivo;

        public static IConversorMoneda ConversorActivo
        {
            get
            {
                if (conversorActivo == null)
                {
                    conversorActivo = GetConversorFromConfig();
                }

                return conversorActivo;
            }
        }

        public static void SetConversor(IConversorMoneda conversor)
        {
            conversorActivo = conversor;
        }

        private static IConversorMoneda GetConversorFromConfig()
        {
            return new MiConversorMoneda();
        }
    }
}