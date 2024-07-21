using System.Windows;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly IUserService iUserService;
        public LoginWindow()
        {
            InitializeComponent();
            iUserService = new UserService();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User u = new User
                {
                    Email = txtEmail.Text,
                    Password = txtPass.Password,
                };
                User user = iUserService.login(u);

                if ((bool)user.IsAdmin)
                {
                    AdminWindow window = new AdminWindow(user);
                    window.Show();
                }
                else
                {
                    UserWindow window = new UserWindow(user);
                    window.Show();
                }
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Login");
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
