using Streamall.Models.Enums;
using Streamall.MVVM;
using System;
using System.Windows.Input;

namespace Streamall.ViewModels
{
    
    internal class MainViewModel : ViewModelBase
    {
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

        public MainViewModel()
        {
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
                    return new StartViewModel();

                case PageType.SEARCH:
                    return new SearchViewModel();

                case PageType.FAVORITES:
                    return new FavoritesViewModel();

                default:
                    throw new ArgumentException(
                        $"No ViewModel found for page type {pageType}",
                        nameof(pageType)
                    );
            }
        }
    }
}