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
    /// Lógica de interação para ProdutoView.xaml
    /// </summary>
    public partial class ProdutoView : UserControl
    {
        private MainWindow _mainWindow;

        public ProdutoView(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow;

            // Carrega os tipos de produto no ComboBox
            cmbTipoProduto.Items.Add("Tabelies");
            cmbTipoProduto.Items.Add("Airbag");
            cmbTipoProduto.Items.Add("Cintos");
        }

        private void Voltar_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.NavigateTo(new HomeView(_mainWindow));
        }

        private void cmbTipoProduto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbTipoProduto.SelectedItem == null) return;

            string tipo = cmbTipoProduto.SelectedItem as string;

            // Oculta todos os campos condicionais por defeito
            lblSubTipo.Visibility = Visibility.Collapsed;
            cmbSubTipo.Visibility = Visibility.Collapsed;
            lblCor.Visibility = Visibility.Collapsed;
            txtCor.Visibility = Visibility.Collapsed;
            lblQuantidadeEstoque.Visibility = Visibility.Collapsed;
            txtQuantidadeEstoque.Visibility = Visibility.Collapsed;

            txtPreco.Clear();
            cmbSubTipo.Items.Clear();

            if (tipo == "Tabelies")
            {
                // Mostra campos de Tabelies
                lblCor.Visibility = Visibility.Visible;
                txtCor.Visibility = Visibility.Visible;
                lblQuantidadeEstoque.Visibility = Visibility.Visible;
                txtQuantidadeEstoque.Visibility = Visibility.Visible;

                // Preço fixo
                txtPreco.Text = "900.00";
            }
            else if (tipo == "Airbag")
            {
                // Mostra campos de Airbag
                lblSubTipo.Visibility = Visibility.Visible;
                cmbSubTipo.Visibility = Visibility.Visible;
                lblSubTipo.Content = "Tipo de Airbag:";

                // Preenche o sub-tipo com o Enum Airbag
                foreach (var tipoAirbag in Enum.GetValues(typeof(Airbag.TipoAirBag)))
                {
                    cmbSubTipo.Items.Add(tipoAirbag);
                }
            }
            else if (tipo == "Cintos")
            {
                // Mostra campos de Cintos
                lblSubTipo.Visibility = Visibility.Visible;
                cmbSubTipo.Visibility = Visibility.Visible;
                lblSubTipo.Content = "Tipo de Cinto:";

                // Preenche o sub-tipo com o Enum Cintos
                foreach (var tipoCinto in Enum.GetValues(typeof(Cintos.TipoCinto)))
                {
                    cmbSubTipo.Items.Add(tipoCinto);
                }
            }
        }

        private void cmbSubTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSubTipo.SelectedItem == null) return;

            // Define o preço com base na seleção do sub-tipo
            string tipoProduto = cmbTipoProduto.SelectedItem as string;

            if (tipoProduto == "Airbag")
            {
                Airbag.TipoAirBag tipo = (Airbag.TipoAirBag)cmbSubTipo.SelectedItem;
                // Lógica de preço do modelo Airbag.cs
                switch (tipo)
                {
                    case Airbag.TipoAirBag.volante: txtPreco.Text = "200.00"; break;
                    case Airbag.TipoAirBag.cortina: txtPreco.Text = "100.00"; break;
                    case Airbag.TipoAirBag.banco: txtPreco.Text = "70.00"; break;
                    case Airbag.TipoAirBag.passageiro: txtPreco.Text = "120.00"; break;
                    case Airbag.TipoAirBag.joelho: txtPreco.Text = "80.00"; break;
                }
            }
            else if (tipoProduto == "Cintos")
            {
                Cintos.TipoCinto tipo = (Cintos.TipoCinto)cmbSubTipo.SelectedItem;
                // Lógica de preço do modelo Cintos.cs
                switch (tipo)
                {
                    case Cintos.TipoCinto.laser: txtPreco.Text = "100.00"; break;
                    case Cintos.TipoCinto.normal: txtPreco.Text = "70.00"; break;
                    case Cintos.TipoCinto.preTensor: txtPreco.Text = "50.00"; break;
                }
            }
        }

        private void SalvarProduto_Click(object sender, RoutedEventArgs e)
        {
            if (cmbTipoProduto.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione um tipo de produto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string tipo = cmbTipoProduto.SelectedItem as string;
            Produto novoProduto = null;

            try
            {
                if (tipo == "Tabelies")
                {
                    Tabelies novoTabelie = new Tabelies
                    {
                        Cor = txtCor.Text,
                        // 'Preco' é definido no construtor do Tabelies
                        QuantidadeEstoque = int.TryParse(txtQuantidadeEstoque.Text, out int qtd) ? qtd : 0
                    };
                    novoProduto = novoTabelie;
                }
                else if (tipo == "Airbag")
                {
                    if (cmbSubTipo.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, selecione o tipo de Airbag.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Airbag.TipoAirBag tipoAirbag = (Airbag.TipoAirBag)cmbSubTipo.SelectedItem;
                    // O construtor define o preço
                    novoProduto = new Airbag(tipoAirbag);
                }
                else if (tipo == "Cintos")
                {
                    if (cmbSubTipo.SelectedItem == null)
                    {
                        MessageBox.Show("Por favor, selecione o tipo de Cinto.", "Erro", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                    Cintos.TipoCinto tipoCinto = (Cintos.TipoCinto)cmbSubTipo.SelectedItem;
                    // O construtor define o preço
                    novoProduto = new Cintos(tipoCinto);
                }

                if (novoProduto == null) return;

                // Preenche os dados comuns da classe base 'Produto'
                novoProduto.Marca = txtMarca.Text;
                novoProduto.CarroModelo = txtCarroModelo.Text;
                novoProduto.Ano = int.TryParse(txtAno.Text, out int ano) ? ano : 2005;

                // 2. Lógica futura para salvar 'novoProduto' no banco de dados SQLite

                MessageBox.Show($"Produto '{novoProduto.Marca} {novoProduto.CarroModelo}' ({tipo}) salvo com sucesso!");
                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao salvar o produto: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LimparCampos()
        {
            cmbTipoProduto.SelectedIndex = -1;
            cmbSubTipo.Items.Clear();
            txtMarca.Clear();
            txtCarroModelo.Clear();
            txtAno.Clear();
            txtQuantidadeEstoque.Clear();
            txtPreco.Clear();
            txtCor.Clear();

            // Redefinir o formulário ao estado inicial
            lblSubTipo.Visibility = Visibility.Collapsed;
            cmbSubTipo.Visibility = Visibility.Collapsed;
            lblCor.Visibility = Visibility.Collapsed;
            txtCor.Visibility = Visibility.Collapsed;
            lblQuantidadeEstoque.Visibility = Visibility.Collapsed;
            txtQuantidadeEstoque.Visibility = Visibility.Collapsed;
        }
    }
}
