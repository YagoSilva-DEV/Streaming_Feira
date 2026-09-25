using Streamall.BLL.Interfaces;
using Streamall.BLL.Interfaces.Contents;
using Streamall.Helpers;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Streamall.ViewModels
{
    internal class FavoritesViewModel : ViewModelBase
    {
        private IUserBLL _userService;
        private UserDTO _userDTO;
        private ObservableCollection<ContentDTO> _favorites;

        public ObservableCollection<ContentDTO> Favorites
        {
            get { return _favorites; }
            set 
            {
                _favorites = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RemoveFavoriteCommand { get; set; }

        public FavoritesViewModel(IUserBLL userBLL, UserDTO userDTO)
        {
            _userService = userBLL;
            _userDTO = userDTO;
            RemoveFavoriteCommand = new RelayCommand(execute => RemoveFavoriteContent(execute as ContentDTO));
            Favorites = new ObservableCollection<ContentDTO>(_userService.GetFavoriteContents(_userDTO.UserId));
        }

        private void RemoveFavoriteContent(ContentDTO content)
        {
            try
            {
                _userService.RemoveFavoriteContent(content.Id, _userDTO.UserId);
                Favorites = new ObservableCollection<ContentDTO>(_userService.GetFavoriteContents(_userDTO.UserId));
            }
            catch
            {

            }
        }
    }
}