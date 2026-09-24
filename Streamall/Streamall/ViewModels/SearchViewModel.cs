using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.MVVM;
using Streamall.Navigation.Interface;
using Streamall.Views.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Streamall.ViewModels
{
    internal class SearchViewModel : ViewModelBase
    {
        private readonly List<ContentDTO> _allContents;
        private string _searchText;
        private INavigationService _navigationService;
        private UserDTO _userDTO;
        public RelayCommand GoToContentHeroCommand { get; set; }
        public ObservableCollection<ContentDTO> Results { get; private set; }

        public string SearchText
        {
            get
            {
                return _searchText;
            }
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterContents();
            }
        }

        public SearchViewModel(IContentBLL contentBLL, INavigationService navigationService, UserDTO userDTO)
        {
            GoToContentHeroCommand = new RelayCommand(execute => GoToContentHero(execute as ContentDTO));
            _navigationService = navigationService;
            _userDTO = userDTO;
            _allContents = contentBLL.GetContentDTOs().ToList();
            Results = new ObservableCollection<ContentDTO>(_allContents);
        }

        private void FilterContents()
        {
            IEnumerable<ContentDTO> filteredContents = _allContents;

            if (!string.IsNullOrWhiteSpace(_searchText))
            {
                filteredContents = _allContents.Where(content =>
                    content.Name != null &&
                    content.Name.IndexOf(
                        _searchText,
                        StringComparison.OrdinalIgnoreCase) >= 0);
            }

            Results.Clear();

            foreach (ContentDTO content in filteredContents)
            {
                Results.Add(content);
            }
        }

        private void GoToContentHero(ContentDTO contentDTO)
        {
            _navigationService.Navigate<ContentDetailsModal>(contentDTO, _userDTO);
        }
    }
}
