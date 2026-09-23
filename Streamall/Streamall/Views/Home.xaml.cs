using System;
using System.Windows;
using Streamall.BLL.Interfaces.Contents;
using Streamall.ViewModels;
using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using Streamall.ViewModels.Contents;
using System.Windows.Controls;

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
