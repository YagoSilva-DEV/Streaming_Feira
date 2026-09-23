using Streamall.Models.DTO;
using Streamall.ViewModels.Users;
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
using Streamall.Navigation.Service;
using System.Windows.Shapes;
using Streamall.BLL.Services;
using Streamall.DAL.Repository;

namespace Streamall.Views
{
    /// <summary>
    /// Interaction logic for AdministratorHome.xaml
    /// </summary>
    public partial class AdministratorHome : Window
    {
        public AdministratorHome()
        {
            DataContext = new AdministratorHomeViewModel();
            InitializeComponent();
        }
        public AdministratorHome(UserDTO admDTO)
        {
            DataContext = new AdministratorHomeViewModel(admDTO, new NavigationService(), () => Close(), new UserServiceBLL(new UserRepositoryDAL()));
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

    }
}
