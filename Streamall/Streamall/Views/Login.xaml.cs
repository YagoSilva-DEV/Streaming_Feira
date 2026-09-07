using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using Streamall.Navigation.Service;
using Streamall.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Streamall.Views
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            DataContext = new LoginViewModel(new ClientServiceBLL(new ClientRepositoryDAL()), new AdministratorServiceBLL(new AdministratorRepositoryDAL()), new NavigationService());
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
