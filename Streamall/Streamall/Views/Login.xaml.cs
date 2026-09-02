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
using Streamall.ViewModels;

namespace Streamall.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            DataContext = new LoginViewModel();
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbBlockName.Visibility = (string.IsNullOrWhiteSpace(txtName.Text)) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbBlockEmail.Visibility = (string.IsNullOrWhiteSpace(txtEmail.Text)) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbBlockPassword.Visibility = (string.IsNullOrWhiteSpace(txtPassword.Text)) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
