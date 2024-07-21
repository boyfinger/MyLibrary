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
using model;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private readonly User user;
        public UserWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadBorrowPage();
        }

        private void LoadBorrowPage()
        {
            frMain.Content = new BorrowPage(user);
        }


        private void btnBorrow_Click(object sender, RoutedEventArgs e)
        {
            LoadBorrowPage();
        }

        private void btnBorrowRecords_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnReservationRecords_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
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
