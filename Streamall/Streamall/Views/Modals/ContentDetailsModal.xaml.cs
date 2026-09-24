using Streamall.Models.DTO;
using System.Windows;
using System.Windows.Input;
using Streamall.Helpers;
using System.Linq;

namespace Streamall.Views.Modals
{
    public partial class ContentDetailsModal : Window
    {
        public ContentDetailsModal(ContentDTO contentDTO)
        {
            InitializeComponent();
            DataContext = contentDTO;

            FavoriteToggle.IsChecked =
                FavoritesStorage.LoadFavoriteIds().Contains(contentDTO.Id);
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void FavoriteButton_Click(object sender, RoutedEventArgs e)
        {
            ContentDTO contentDTO = DataContext as ContentDTO;

            if (contentDTO == null)
            {
                return;
            }

            if (FavoriteToggle.IsChecked == true)
            {
                FavoritesStorage.AddFavorite(contentDTO.Id);
            }
            else
            {
                FavoritesStorage.RemoveFavorite(contentDTO.Id);
            }
        }
    }
}