using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using Streamall.Models.Enums;
using Streamall.ViewModels.Contents;
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

namespace Streamall.Views.Modals
{
    /// <summary>
    /// Interaction logic for AddFilmMakerModal.xaml
    /// </summary>
    public partial class AddCatalogItemModal : Window
    {
        public AddCatalogItemModal(CatalogItemType catalogItemType)
        {
            InitializeComponent();
            DataContext = new AddCatalogItemModalViewModel(catalogItemType,
                new GenreServiceBLL(new GenreRepositoryDAL()),
                new FilmMakerServiceBLL(new FilmMakerRepositoryDAL()),
                () => Close());
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}
