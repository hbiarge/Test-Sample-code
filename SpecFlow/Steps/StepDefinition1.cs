using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace SpecFlow.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private Cuenta cuenta1;
        private Cuenta cuenta2;

        [Given(@"que tengo una cuenta de moneda euros y saldo 100")]
        public void DadoQueTengoUnaCuentaDeMonedaEurosYSaldo100()
        {
            cuenta1 = new Cuenta(1, Moneda.Euro, 100M);
        }

        [Given(@"tengo otra cuenta de moneda euros y saldo 50")]
        public void DadoTengoOtraCuentaDeMonedaEurosYSaldo50()
        {
            cuenta2 = new Cuenta(2, Moneda.Euro, 50M);
        }

        [Then(@"la otra cuenta tiene 100 euros")]
        public void EntoncesLaOtraCuentaTiene100Euros()
        {
            Assert.AreEqual(100, cuenta2.Saldo);
        }

        [Then(@"mi cuenta tiene 50 euros")]
        public void EntoncesMiCuentaTiene50Euros()
        {
            Assert.AreEqual(50, cuenta1.Saldo);
        }

        [When(@"tranfiero 50 euros de mi cuenta a la otra")]
        public void CuandoTranfiero50EurosDeMiCuentaALaOtra()
        {
            cuenta1.Transferir(50, cuenta2);
        }
    }

}
