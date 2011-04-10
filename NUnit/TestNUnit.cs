using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace NUnit
{
    using Library;
    using Library.Conversion;

    [TestFixture]
    public class TestNUnit
    {
        [TestFixtureSetUp]
        public static void TestFixtureSetUp()
        {

        }

        [TestFixtureTearDown]
        public static void TestFixtureTearDown()
        {

        }

        [SetUp]
        public void SetUp()
        {

        }

        [TearDown]
        public void TearDowm()
        {

        }

        [TestCase(Moneda.Euro, Moneda.Euro, 1)]
        [TestCase(Moneda.Euro, Moneda.Yen, 0.90)]
        [TestCase(Moneda.Euro, Moneda.Dolar, 0.79)]
        [Test]
        public void PrimerTest(Moneda de, Moneda a, decimal ratio)
        {
            var target = new MiConversorMoneda();

            var result = target.RatioConversion(de, a);

            Assert.AreEqual(ratio, result);
        }

        [Test]
        public void SegundoTest()
        {
            var target = new Cuenta(1, Moneda.Euro, 100);

            Assert.IsNotNull(target);
        }

        [Test]
        public void TercerTest()
        {
            var primero = FactoriaConversion.ConversorActivo;
            var segundo = FactoriaConversion.ConversorActivo;

            Assert.IsNotNull(primero);
            Assert.IsNotNull(segundo);
            Assert.AreSame(primero, segundo);
        }
    }
}
