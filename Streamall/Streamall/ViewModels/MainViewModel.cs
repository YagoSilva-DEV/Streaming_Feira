using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.Enums;
using Streamall.MVVM;
using System;
using System.Windows.Input;

namespace Streamall.ViewModels
{
    
    internal class MainViewModel : ViewModelBase
    {
        private readonly IContentBLL _contentBLL;
        private ViewModelBase _currentViewModel;
        private PageType _selectedPage;

        public ViewModelBase CurrentViewModel
        {
            get => _currentViewModel;
            private set
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


        // Commands

        public ICommand HomeCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand FavoritesCommand { get; }       

        public MainViewModel(IContentBLL contentBLL)
        {
            _contentBLL = contentBLL;
            HomeCommand = new RelayCommand(_ => Navigate(PageType.START));
            SearchCommand = new RelayCommand(_ => Navigate(PageType.SEARCH));
            FavoritesCommand = new RelayCommand(_ => Navigate(PageType.FAVORITES));

            Navigate(PageType.START);
        }


        // Navegação

        private void Navigate(PageType pageType)
        {
            SelectedPage = pageType;
            CurrentViewModel = CreateViewModel(pageType);
        }


        // Criação do ViewModel

        private ViewModelBase CreateViewModel(PageType pageType)
        {
            switch (pageType)
            {
                case PageType.START:
                    return new StartViewModel(_contentBLL);

                case PageType.SEARCH:
                    return new SearchViewModel(_contentBLL);

                case PageType.FAVORITES:
                    return new FavoritesViewModel(_contentBLL);

                default:
                    throw new ArgumentException(
                        $"No ViewModel found for page type {pageType}",
                        nameof(pageType)
                    );
            }
        }
    }
}