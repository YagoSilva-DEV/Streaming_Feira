using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using Streamall.Helpers;
using Streamall.ViewModels;
using System;
using System.Windows;

namespace Streamall.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            Action signUpSuccessAction = () => Close();
            InitializeComponent();
            DataContext = new SignUpViewModel(new ClientServiceBLL(new ClientRepositoryDAL()), signUpSuccessAction);
        }

        private void txtFullName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tbFullName.Visibility = (string.IsNullOrWhiteSpace(txtFullName.Text)) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtUserName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tbUserName.Visibility = (string.IsNullOrWhiteSpace(txtUserName.Text)) ? Visibility.Visible : Visibility.Hidden;
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            tbEmail.Visibility = (string.IsNullOrWhiteSpace(txtEmail.Text)) ? Visibility.Visible : Visibility.Hidden;
        }
        private void pbPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            tbPassword.Visibility = (string.IsNullOrWhiteSpace(pbPassword.Password)) ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
