using Streamall.BLL.Interfaces.Contents;
using Streamall.Helpers;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Streamall.ViewModels
{
    internal class FavoritesViewModel : ViewModelBase
    {
        public ObservableCollection<ContentDTO> Favorites { get; private set; }

        public FavoritesViewModel(IContentBLL contentBLL)
        {
            List<int> favoriteIds = FavoritesStorage.LoadFavoriteIds();

            Favorites = new ObservableCollection<ContentDTO>(
                contentBLL.GetContentDTOs()
                    .Where(content => favoriteIds.Contains(content.Id)));
        }
    }
}