using Streamall.BLL.Interfaces.Contents;
using Streamall.BLL.Services.Contents;
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
        public Home()
        {
            InitializeComponent();

            DataContext = new CarroselViewModel(new ContentServiceBLL(new ContentRepositoryDAL()));
        }
        private void SideBar_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
