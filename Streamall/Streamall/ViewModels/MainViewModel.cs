using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.Enums;
using Streamall.MVVM;
using System;
using System.Windows.Input;
using Streamall.ViewModels.Contents;
using Streamall.Models.DTO;
using Streamall.BLL.Interfaces;
using Streamall.Navigation.Service;

namespace Streamall.ViewModels
{
    
    public class MainViewModel : ViewModelBase
    {
        private readonly IContentBLL _contentBLL;
        private ViewModelBase _currentViewModel;
        private PageType _selectedPage;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public PageType SelectedPage
        {
            get => _selectedPage;
            private set
            {
                _selectedPage = value;
                OnPropertyChanged();
            }
        }

        private IUserBLL _userService;
        private Action _closeWindow;
        private UserDTO _userDTO;
        // Commands

        public ICommand HomeCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand FavoritesCommand { get; }
        public ICommand ExitCommand { get; set; }

        public MainViewModel(IContentBLL contentBLL, UserDTO userDTO, Action closeWindow, IUserBLL userBLL)
        {
            _contentBLL = contentBLL;
            _userDTO = userDTO;
            _closeWindow = closeWindow;
            _userService = userBLL;
            HomeCommand = new RelayCommand(_ => Navigate(PageType.START));
            SearchCommand = new RelayCommand(_ => Navigate(PageType.SEARCH));
            FavoritesCommand = new RelayCommand(_ => Navigate(PageType.FAVORITES));
            ExitCommand = new RelayCommand(execute => Exit());

            Navigate(PageType.START);
        }


        // Navegação

        public void Navigate(PageType pageType)
        {
            SelectedPage = pageType;
            CurrentViewModel = CreateViewModel(pageType);
        }


        // Criação do ViewModel

        public ViewModelBase CreateViewModel(PageType pageType)
        {
            switch (pageType)
            {
                case PageType.START:
                    return new StartViewModel(_contentBLL, _userDTO);

                case PageType.SEARCH:
                    return new SearchViewModel(_contentBLL, new NavigationService(), _userDTO);

                case PageType.FAVORITES:
                    return new FavoritesViewModel(_contentBLL);

                default:
                    throw new ArgumentException(
                        $"No ViewModel found for page type {pageType}",
                        nameof(pageType)
                    );
            }
        }

        private void Exit()
        {
            _userService.KeepUserInactive(_userDTO.UserId);
            _closeWindow.Invoke();
        }
    }
}