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

namespace Streamall.Views.UserControls
{
    /// <summary>
    /// Interaction logic for LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbBlockName.Visibility = (string.IsNullOrWhiteSpace(txtName.Text)) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            tbBlockEmail.Visibility = (string.IsNullOrWhiteSpace(txtEmail.Text)) ? Visibility.Visible : Visibility.Hidden;
        }

        private void pbPassword_PasswordChanged_1(object sender, RoutedEventArgs e)
        {
            tbBlockPassword.Visibility = (string.IsNullOrWhiteSpace(pbPassword.Password)) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
