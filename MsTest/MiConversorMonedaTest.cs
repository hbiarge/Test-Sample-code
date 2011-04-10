using System.Moles;
using Library.Conversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Library;

namespace MsTest
{
    /// <summary>
    ///This is a test class for MiConversorMonedaTest and is intended
    ///to contain all MiConversorMonedaTest Unit Tests
    ///</summary>
    [TestClass()]
    public class MiConversorMonedaTest
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


        [TestMethod()]
        [HostType("Moles")]
        public void RatioConversionSabado()
        {
            MDateTime.TodayGet = () => new DateTime(2011, 4, 9);

            var target = new MiConversorMoneda();
            const decimal expected = 1M;

            var result = target.RatioConversion(Moneda.Dolar, Moneda.Euro);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [HostType("Moles")]
        public void RatioConversionNormal()
        {
            MDateTime.TodayGet = () => new DateTime(2011, 4, 8);

            var target = new MiConversorMoneda();
            const decimal expected = 1.40M;

            var result = target.RatioConversion(Moneda.Dolar, Moneda.Euro);

            Assert.AreEqual(expected, result);
        }
    }
}
