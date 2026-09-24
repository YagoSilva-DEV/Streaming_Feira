using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.MVVM;
using Streamall.Navigation.Interface;
using Streamall.Views.Modals;
using System.Collections.ObjectModel;
using System.Windows;

namespace Streamall.ViewModels.Contents
{
    public class CarroselViewModel : ViewModelBase
    {
        private UserDTO _userDTO;
        private readonly IContentBLL _contentBLL;
        private INavigationService _navigationService;
        public RelayCommand GoToContentHeroCommand { get; set; }
        public ObservableCollection<ContentDTO> Recommendations { get; set; }
        public ObservableCollection<ContentDTO> Actions { get; set; }
        public ObservableCollection<ContentDTO> Dramas { get; set; }
        public ObservableCollection<ContentDTO> ScienceFictions { get; set; }
        public ObservableCollection<ContentDTO> Animations { get; set; }
        public ObservableCollection<ContentDTO> Documentaries { get; set; }

        public CarroselViewModel(IContentBLL contentBLL, UserDTO user, INavigationService navigationService)
        {
            _contentBLL = contentBLL;
            _navigationService = navigationService;
            Recommendations = new ObservableCollection<ContentDTO>(
                _contentBLL.GetRecomendationContens());

            Actions = new ObservableCollection<ContentDTO>(
                _contentBLL.GetActionContens());

            Dramas = new ObservableCollection<ContentDTO>(
                _contentBLL.GetDramaContens());

            ScienceFictions = new ObservableCollection<ContentDTO>(
                _contentBLL.GetScienceFictionContens());

            Animations = new ObservableCollection<ContentDTO>(
                _contentBLL.GetAnimationContens());

            Documentaries = new ObservableCollection<ContentDTO>(
                _contentBLL.GetDocumentaryContens());

            _userDTO = user;
            GoToContentHeroCommand = new RelayCommand(execute => GoToContentHero(execute as ContentDTO));
        }

        private void GoToContentHero(ContentDTO contentDTO) 
        {
            _navigationService.Navigate<ContentDetailsModal>(contentDTO, _userDTO);
        }
    }
}