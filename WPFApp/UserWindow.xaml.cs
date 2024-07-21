using System.Windows;
using model;

namespace WPFApp
{
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
            frMain.Content = new BorrowRecordsPage(user);
        }

        private void btnReservationRecords_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new ReservationRecordsPage(user);
        }

        private void btnComments_Click(object sender, RoutedEventArgs e)
        {
            frMain.Content = new CommentsPage(user);
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
