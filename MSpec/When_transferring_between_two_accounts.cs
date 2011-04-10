using Library.Conversion;
using Library.Loging;
using Machine.Specifications;
using Library;
using Moq;
using It = Machine.Specifications.It;

namespace MSpec
{
    [Subject(typeof(Cuenta), "Funds transfer")]
    public class When_transferring_between_two_accounts
    {
        static Cuenta deCuenta;
        static Cuenta aCuenta;

        Establish context = () =>
            {
                var ratio = 1M;
                var conversor = new Mock<IConversorMoneda>();
                conversor
                    .Setup(x => x.RatioConversion(Moq.It.IsAny<Moneda>(), Moq.It.IsAny<Moneda>()))
                    .Returns(ratio);

                var logger = new Mock<ILoger>();

                FactoriaConversion.SetConversor(conversor.Object);
                FactoriaLogger.SetLogger(logger.Object);

                deCuenta = new Cuenta(1, Moneda.Euro, 1M);
                aCuenta = new Cuenta(2, Moneda.Euro, 1M);
            };

        Because of = () => deCuenta.Transferir(1M, aCuenta);

        It shoud_debit_the_from_Account_by_the_amount_transferred = () => deCuenta.Saldo.ShouldEqual(0M);

        It shoud_credit_the_to_Account_by_the_amount_transferred = () => aCuenta.Saldo.ShouldEqual(2M);
    }
}
