using System.Windows;
using model;

namespace WPFApp
{
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            loadBookPage();
        }

        private void loadBookPage()
        {
            frMain.Content = new BooksManagementPage();
        }

        private void btnManageBooks_Click(object sender, RoutedEventArgs e)
        {
            loadBookPage();
        }

        private void btnManageUsers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
