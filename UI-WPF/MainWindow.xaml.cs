using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UI_WPF
{
    using Library;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string Nl = Environment.NewLine;
        private readonly RepositorioCuentas repositorio = new RepositorioCuentas();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lbOrigen.ItemsSource = repositorio.GetAll().ToList();
            lbDestino.ItemsSource = repositorio.GetAll().ToList();

            Library.Events.EventManager.Current.GetEvent<string>()
                .Subscribe(Log);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            decimal cantidad;
            var ok = decimal.TryParse(txtCantidad.Text, out cantidad);

            if (!ok)
            {
                Log("Debe introducir un valor numérico en la cantidad");
                txtCantidad.Focus();
                return;
            }

            if (lbOrigen.SelectedItem == null)
            {
                Log("Debe Seleccionar la cuenta de origen.");
                return;
            }

            if (lbDestino.SelectedItem == null)
            {
                Log("Debe Seleccionar la cuenta de destino.");
                return;
            }

            var origen = (Cuenta)this.lbOrigen.SelectedItem;
            var destino = (Cuenta)this.lbDestino.SelectedItem;

            this.Log(string.Format("{0} ({1})-> Saldo: {2}", origen.NumeroCuenta, origen.Moneda, origen.Saldo));
            this.Log(string.Format("{0} ({1})-> Saldo: {2}", destino.NumeroCuenta, destino.Moneda, destino.Saldo));

            origen.Transferir(cantidad, destino);

            this.Log(string.Format("{0} ({1})-> Saldo: {2}", origen.NumeroCuenta, origen.Moneda, origen.Saldo));
            this.Log(string.Format("{0} ({1})-> Saldo: {2}", destino.NumeroCuenta, destino.Moneda, destino.Saldo));

            txtCantidad.Clear();
            lbOrigen.SelectedItem = null;
            lbDestino.SelectedItem = null;
        }

        private void Log(string message)
        {
            this.txtLog.AppendText(string.Format(message + Nl));
            this.txtLog.ScrollToEnd();
        }
    }
}
