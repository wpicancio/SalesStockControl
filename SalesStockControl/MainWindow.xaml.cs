using SalesStockControl.Views;
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

namespace SalesStockControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Define o conteúdo inicial como a tela de Login.
            // Passamos 'this' (a própria MainWindow) para o Login, 
            // para que o Login possa nos dizer quando navegar.
            MainContentHost.Content = new Login(this);
        }

        /// <summary>
        /// Método público para trocar a tela (UserControl) exibida no ContentControl.
        /// </summary>
        /// <param name="newView">A nova tela (UserControl) a ser exibida.</param>
        public void NavigateTo(UserControl newView)
        {
            MainContentHost.Content = newView;
        }
    }
}