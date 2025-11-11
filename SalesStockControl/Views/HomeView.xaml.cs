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
using System.Windows.Shapes;

namespace SalesStockControl.Views
{
    /// <summary>
    /// Lógica de interação para HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        private MainWindow _mainWindow;

        public HomeView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
        }

        private void RegistrarVenda_Click(object sender, RoutedEventArgs e)
        {
            // Pede à MainWindow para navegar para a nova VendasView
            _mainWindow.NavigateTo(new VendasView(_mainWindow));
        }

        private void CadastrarCliente_Click(object sender, RoutedEventArgs e)
        {
            // Pede à MainWindow para navegar para a nova ClienteView
            _mainWindow.NavigateTo(new ClienteView(_mainWindow));
        }

        private void GestaoProdutos_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new ProdutoView(_mainWindow));
        }
    }
}