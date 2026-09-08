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
            Action signUpSuccessAction = () => { MessageBoxHelper.ShowMessageBoxSuccess("Cadastro realizado com sucesso"); Close(); };
            InitializeComponent();
            DataContext = new SignUpViewModel(new ClientServiceBLL(new ClientRepositoryDAL()), signUpSuccessAction);
        }

        private void txtFullName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFullName.Text))
                tbFullName.Visibility = Visibility.Hidden;
            else
                tbFullName.Visibility = Visibility.Visible;
        }

        private void txtUserName_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtUserName.Text))
                tbUserName.Visibility = Visibility.Hidden;
            else
                tbUserName.Visibility = Visibility.Visible;
        }

        private void txtEmail_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                tbEmail.Visibility = Visibility.Hidden;
            else
                tbEmail.Visibility = Visibility.Visible;
        }

        private void txtPassword_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                tbPassword.Visibility = Visibility.Hidden;
            else
                tbPassword.Visibility = Visibility.Visible;
        }
    }
}
