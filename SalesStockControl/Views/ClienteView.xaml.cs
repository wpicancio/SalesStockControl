using SalesStockControl.Models;
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
    /// Lógica de interação para ClienteView.xaml
    /// </summary>
    public partial class ClienteView : UserControl
    {
        private MainWindow _mainWindow;

        public ClienteView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            // Define a data de hoje no DatePicker, como o seu modelo sugere
            dpDateCad.SelectedDate = DateTime.Now;
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            // Pede à MainWindow para navegar de volta para o menu principal (HomeView)
            _mainWindow.NavigateTo(new HomeView(_mainWindow));
        }

        private void SalvarCliente_Click(object sender, RoutedEventArgs e)
        {
            // 1. Criar um novo objeto Cliente com os dados da tela
            Cliente novoCliente = new Cliente
            {
                Nome = txtNome.Text,
                NomeDaOficina = txtNomeOficina.Text,
                Nif = txtNIF.Text,
                Telemovel = txtTelemovel.Text, // Usando 'Telefone' do Contacto.cs
                Morada = txtMorada.Text,
                DateCad = dpDateCad.SelectedDate.GetValueOrDefault(DateTime.Now) // Pega a data do DatePicker
            };

            // 2. Lógica futura para salvar o 'novoCliente' no banco de dados SQLite

            // 3. Feedback ao utilizador
            MessageBox.Show($"Cliente '{novoCliente.Nome}' salvo com sucesso! (Implementação futura no DB)");

            // 4. Opcional: Limpar os campos após salvar
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtNomeOficina.Clear();
            txtNIF.Clear();
            txtTelemovel.Clear();
            txtMorada.Clear();
            // Reinicia a data para o dia atual
            dpDateCad.SelectedDate = DateTime.Now;
        }
    }
}
