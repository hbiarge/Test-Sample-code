using Library;
using Library.Conversion;
using Library.Conversion.Moles;
using Library.Loging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;

namespace MsTest
{
    /// <summary>
    ///This is a test class for CuentaTest and is intended
    ///to contain all CuentaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CuentaTest
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        /// <summary>
        ///A test for Transferir
        ///</summary>
        [TestMethod()]
        public void TransferirTest()
        {
            var ratio = 1.25M;
            var conversor = new Mock<IConversorMoneda>();
            conversor
                .Setup(x => x.RatioConversion(It.IsAny<Moneda>(), It.IsAny<Moneda>()))
                .Returns(ratio);

            var logger = new Mock<ILoger>();

            FactoriaConversion.SetConversor(conversor.Object);
            FactoriaLogger.SetLogger(logger.Object);

            int numeroCuenta = 1;
            Moneda moneda = Moneda.Euro;
            Decimal saldo = 100M;
            Cuenta target = new Cuenta(numeroCuenta, moneda, saldo);
            Decimal cantidad = 50;
            int numeroCuenta2 = 2;
            Moneda moneda2 = Moneda.Dolar;
            Decimal saldo2 = 100M;
            Cuenta aCuenta = new Cuenta(numeroCuenta2, moneda2, saldo2);

            target.Transferir(cantidad, aCuenta);

            Assert.AreEqual(saldo - cantidad, target.Saldo);
            Assert.AreEqual(saldo2 + (cantidad * ratio), aCuenta.Saldo);
            logger.Verify(x => x.Log(It.IsAny<string>()), Times.Never());
        }
    }
}
