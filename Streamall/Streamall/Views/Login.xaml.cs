using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using Streamall.Navigation.Service;
using Streamall.ViewModels;
using Streamall.ViewModels.Users;
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
            DataContext = new LoginWindowViewModel(() => Close());
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
 
    }
}
