using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interação para VendasView.xaml
    /// </summary>
    public partial class VendasView : UserControl
    {
        private MainWindow _mainWindow;
        private CultureInfo _cultureInfo = new CultureInfo("pt-PT");

        public VendasView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            CleanForm();
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new HomeView(_mainWindow));
        }

        private void SalvarButton_Click(object sender, RoutedEventArgs e)
        {
            if (RadioButtonTabelieSim.IsChecked == true)
            {
                bool emEstoque = false;

                if (!emEstoque)
                {
                    MessageBoxResult aviso = MessageBox.Show(
                        "Este Tabelies não se encontra em estoque e terá de ser encomendado.\n\nDeseja continuar a salvar a venda mesmo assim?",
                        "Aviso de Encomenda",
                        MessageBoxButton.YesNo,
                        MessageBoxImage.Warning);

                    if (aviso == MessageBoxResult.No)
                    {
                        return;
                    }
                }
            }

            MessageBox.Show("Venda salva com sucesso!");
            CleanForm();
        }

        private void LimparButton_Click(object sender, RoutedEventArgs e)
        {
            CleanForm();
        }

        // --- LÓGICA DE CÁLCULO TOTAL (CORRIGIDA) ---

        private void AtualizarTotal_Event(object sender, RoutedEventArgs e)
        {
            // O 'if (this.IsLoaded)' previne que este código corra
            // antes da janela estar totalmente carregada, evitando erros.
            if (this.IsLoaded)
            {
                CalcularTotal();
            }
        }

        /// <summary>
        /// Lê um valor (quantidade) de um ComboBox de forma segura.
        /// </summary>
        private int GetQtdFromComboBox(ComboBox cmb)
        {
            if (cmb.SelectedItem is ComboBoxItem item && item.Content != null)
            {
                int.TryParse(item.Content.ToString(), out int qtd);
                return qtd;
            }
            return 0; // Retorna 0 se nada estiver selecionado ou o conteúdo for nulo
        }

        /// <summary>
        /// Lê todos os controlos e calcula o preço final (VERSÃO SEGURA).
        /// </summary>
        private void CalcularTotal()
        {
            decimal total = 0;

            // 1. Verificar Tabelier
            if (RadioButtonTabelieSim.IsChecked == true)
            {
                total += 900.00m;
            }

            // 2. Verificar Airbags
            if (chkAirbagVolante.IsChecked == true) total += 200.00m;
            if (chkAirbagPassageiro.IsChecked == true) total += 120.00m;
            if (chkAirbagJoelho.IsChecked == true) total += 80.00m;

            // Airbags com Quantidade (Forma Segura)
            if (chkAirbagCortina.IsChecked == true)
            {
                int qtd = GetQtdFromComboBox(cmbAirbagCortina); // <--- CORREÇÃO
                total += (100.00m * qtd); // Preço Cortina
            }
            if (chkAirbagBanco.IsChecked == true)
            {
                int qtd = GetQtdFromComboBox(cmbAirbagBanco); // <--- CORREÇÃO
                total += (70.00m * qtd); // Preço Banco
            }

            // 3. Verificar Cintos
            if (chkCintoNormal.IsChecked == true)
            {
                int qtd = GetQtdFromComboBox(cmbCintoNormal); // <--- CORREÇÃO
                total += (70.00m * qtd); // Preço Normal
            }
            if (chkCintoLaser.IsChecked == true)
            {
                int qtd = GetQtdFromComboBox(cmbCintoLaser); // <--- CORREÇÃO
                total += (100.00m * qtd); // Preço Laser
            }
            if (chkCintoPreTensor.IsChecked == true)
            {
                int qtd = GetQtdFromComboBox(cmbCintoPreTensor); // <--- CORREÇÃO
                total += (50.00m * qtd); // Preço PreTensor
            }

            // 4. Atualizar o TextBox
            txtTotalVenda.Text = total.ToString("C", _cultureInfo);
        }

        // --- FORMULÁRIO LIMPO ATUALIZADO ---

        private void CleanForm()
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
            RadioButtonTabelie.IsChecked = true; // Radio "Não"

            // Limpa AirBags
            chkAirbagVolante.IsChecked = false;
            chkAirbagPassageiro.IsChecked = false;
            chkAirbagJoelho.IsChecked = false;
            chkAirbagCortina.IsChecked = false;
            cmbAirbagCortina.SelectedIndex = -1;
            chkAirbagBanco.IsChecked = false;
            cmbAirbagBanco.SelectedIndex = -1;

            // Limpa Cintos
            chkCintoNormal.IsChecked = false;
            cmbCintoNormal.SelectedIndex = -1;
            chkCintoLaser.IsChecked = false;
            cmbCintoLaser.SelectedIndex = -1;
            chkCintoPreTensor.IsChecked = false;
            cmbCintoPreTensor.SelectedIndex = -1;

            //Situação
            RadioButtonEntregueNao.IsChecked = true;
            RadioButtonPagoNao.IsChecked = true;

            // Garante que o cálculo só corre depois da janela estar carregada
            if (this.IsLoaded)
            {
                CalcularTotal();
            }
            else
            {
                txtTotalVenda.Text = (0m).ToString("C", _cultureInfo);
            }
        }
    }
}