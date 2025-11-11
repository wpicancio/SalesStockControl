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
    /// Interação lógica para Login.xam
    /// </summary>
    public partial class Login : UserControl
    {
        // Guarda a referência da janela principal para navegação
        private MainWindow _mainWindow;

        // Defina uma senha simples para teste.
        private const string USUARIO_CORRETO = "admin";
        private const string SENHA_CORRETA = "1234";

        // Construtor modificado para receber a MainWindow
        public Login(MainWindow mainWindow)
        {
            InitializeComponent();
            _mainWindow = mainWindow; // Armazena a referência
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            if (username == USUARIO_CORRETO && password == SENHA_CORRETA)
            {
                // Login bem-sucedido: Navega para a HomeView
               
                _mainWindow.NavigateTo(new HomeView(_mainWindow));
            }
            else
            {
                // Login falhou
                MessageBox.Show("Usuário ou senha incorretos.", "Erro de Login", MessageBoxButton.OK, MessageBoxImage.Error);
                txtPassword.Clear(); // Limpa o campo de senha
            }
        }
    }
}
