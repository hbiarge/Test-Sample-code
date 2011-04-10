namespace Library.Loging
{
    public static class FactoriaLogger
    {
        private static ILoger logerActivo;

        public static ILoger LogerActivo
        {
            get
            {
                if (logerActivo == null)
                {
                    logerActivo = GetLoggerFromConfig();
                }

                return logerActivo;
            }
        }

        public static void SetLogger(ILoger loger)
        {
            logerActivo = loger;
        }

        private static ILoger GetLoggerFromConfig()
        {
            return new MemoryLogger();
        }
    }
}