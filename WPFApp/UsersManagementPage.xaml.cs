using System.Windows;
using System.Windows.Controls;
using model;
using service;
using service.Interfaces;

namespace WPFApp
{
    public partial class UsersManagementPage : Page
    {
        private readonly IUserService iUserService;

        public UsersManagementPage()
        {
            InitializeComponent();
            iUserService = new UserService();
            LoadList();
        }

        private void LoadList()
        {
            lvUser.ItemsSource = iUserService.getAllUsers();
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                string fullName = txtFullName.Text;
                if (fullName == null || fullName.Length == 0)
                {
                    throw new Exception("Please enter user's full name!");
                }
                user.FullName = fullName;

                string email = txtEmail.Text;
                if (email == null  || email.Length == 0)
                {
                    throw new Exception("Please enter email!");
                }
                user.Email = email;

                string password = txtPassword.Text;
                if (password == null  || password.Length == 0)
                {
                    throw new Exception("Please enter pasword");
                }
                user.Password = password;

                User u = iUserService.insertUser(user);
                LoadList();
                MessageBox.Show($"Insert user with email {u.Email} successfully!", "Insert user");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message, "Insert user");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                try
                {
                    int userId = int.Parse(txtUserID.Text);
                    user.UserId = userId;
                }
                catch
                {
                    throw new Exception("Please select an user!");
                }
                string fullName = txtFullName.Text;
                if (fullName == null || fullName.Length == 0)
                {
                    throw new Exception("Please enter user's full name!");
                }
                user.FullName = fullName;

                string email = txtEmail.Text;
                if (email == null || email.Length == 0)
                {
                    throw new Exception("Please enter email!");
                }
                user.Email = email;

                string password = txtPassword.Text;
                if (password == null || password.Length == 0)
                {
                    throw new Exception("Please enter pasword");
                }
                user.Password = password;

                User u = iUserService.updateUser(user);
                LoadList();
                MessageBox.Show($"Update user with id {u.UserId} successfully!", "Update user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update user");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User user = new User();
                try
                {
                    int userId = int.Parse(txtUserID.Text);
                    user.UserId = userId;
                }
                catch
                {
                    throw new Exception("Please select an user!");
                }

                User u = iUserService.removeUser(user);
                LoadList();
                MessageBox.Show($"Remove user with email {u.Email} successfully!", "Remove user");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Remove user");
            }
        }
    }
}
