using Streamall.BLL.Interfaces.Contents;
using Streamall.BLL.Services;
using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository;
using Streamall.DAL.Repository.Contents;
using Streamall.Models.DTO;
using Streamall.ViewModels;
using Streamall.ViewModels.Contents;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Streamall.Views
{
    /// <summary>
    /// Lógica interna para Home.xaml
    /// </summary>
    public partial class Home : Window
    {
        public Home(UserDTO userDTO)
        {
            InitializeComponent();

            DataContext = new MainViewModel(new ContentServiceBLL(new ContentRepositoryDAL()), userDTO, () => Close(), new UserServiceBLL(new UserRepositoryDAL()));
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
