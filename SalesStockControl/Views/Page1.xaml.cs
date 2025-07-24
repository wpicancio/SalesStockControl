using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SalesStockControl.Views
{
    /// <summary>
    /// Interação lógica para Page1.xam
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();
            CleanForm();
        }

        private async void CleanForm()
        {
            //Venda
            ClienteOpt.SelectedIndex = -1;
            DataVenda.SelectedDate = null;
           //Modelo 
            MarcaVendaOpt.SelectedIndex = -1;
            txtAnoVenda.Text = "";
            txtModeloVenda.Text = "";
            //Tabelie
            CorTabelieOpt.SelectedIndex = -1;
            foreach (var child in WrapCamposAirBags.Children)
            {
                // Aqui "child" será cada controle dentro do WrapPanel
                if (child is CheckBox cb)
                    cb.IsChecked = false;

                else if (child is ComboBox combo)
                    combo.SelectedIndex = -1;
            }
            foreach (var child in WrapCamposCintos.Children)
            {
                // Aqui "child" será cada controle dentro do WrapPanel
                if (child is CheckBox cb)
                    cb.IsChecked = false;

                else if (child is ComboBox combo)
                    combo.SelectedIndex = -1;
            }
            txtTotalVenda.Text = " ";
            RadioButtonEntregueNao.IsChecked = true;
            RadioButtonPagoNao.IsChecked = true;
            RadioButtonTabelie.IsChecked = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CleanForm();
        }
    }
}
