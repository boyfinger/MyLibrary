using System.Windows;
using model;

namespace WPFApp
{
    public partial class AdminWindow : Window
    {
        private readonly User user;
        public AdminWindow(User user)
        {
            InitializeComponent();
            this.user = user;
        }


    }
}
