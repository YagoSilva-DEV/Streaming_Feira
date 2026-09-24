using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System.Collections.ObjectModel;

namespace Streamall.ViewModels.Contents
{
    public class CarroselViewModel : ViewModelBase
    {
        private MainViewModel _viewModel;
        private readonly IContentBLL _contentBLL;
        public RelayCommand GoToContentHeroCommand { get; set; }
        public ObservableCollection<ContentDTO> Recommendations { get; set; }
        public ObservableCollection<ContentDTO> Actions { get; set; }
        public ObservableCollection<ContentDTO> Dramas { get; set; }
        public ObservableCollection<ContentDTO> ScienceFictions { get; set; }
        public ObservableCollection<ContentDTO> Animations { get; set; }
        public ObservableCollection<ContentDTO> Documentaries { get; set; }

        public CarroselViewModel(IContentBLL contentBLL, MainViewModel viewModel)
        {
            _contentBLL = contentBLL;

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

            _viewModel = viewModel;

            GoToContentHeroCommand = new RelayCommand(execute => GoToContentHero(execute as ContentDTO));
        }

        private void GoToContentHero(ContentDTO contentDTO) 
        {
            _viewModel.Navigate(Models.Enums.PageType.CONTENTHERO);
        }
    }
}