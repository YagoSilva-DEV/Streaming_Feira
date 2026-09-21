using Streamall.BLL.Interfaces.Contents;
using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using Streamall.Exceptions;
using Streamall.Helpers;
using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels.Contents
{
    public class EditContentModalViewModel : ViewModelBase
    {
        private IContentBLL _contentBLL;
        private EditContentControlViewModel _storedEditContentControlViewModel;
        private Action _closeWindow;
        private ContentDTO _newContentDTO;
        public ContentDTO StoredContentDTO { get; set; }
        private object _currentViewModel;
        public RelayCommand SaveCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        public EditContentModalViewModel(IContentBLL contentBLL, ContentDTO contentDTO, Action closeWindow)
        {
            _contentBLL = contentBLL;
            StoredContentDTO = contentDTO;
            SaveCommand = new RelayCommand(execute => Save());
            CancelCommand = new RelayCommand(async execute => { await Cancel(); });
            CurrentViewModel = new EditContentControlViewModel(StoredContentDTO, new ContentServiceBLL(new ContentRepositoryDAL()));
            _closeWindow = closeWindow;
        }

        private async void Save()
        {
            if (CurrentViewModel is EditContentControlViewModel)
            {
                _storedEditContentControlViewModel = CurrentViewModel as EditContentControlViewModel;
                _newContentDTO = new ContentDTO(StoredContentDTO.Id, _storedEditContentControlViewModel.NewName, _storedEditContentControlViewModel.NewSynopsis, _storedEditContentControlViewModel.NewPathCover, _storedEditContentControlViewModel.NewReleaseDate, _storedEditContentControlViewModel.NewGenre, _storedEditContentControlViewModel.NewFilmMaker, StoredContentDTO.ContentType);
                CurrentViewModel = new ConfirmEditContentViewModel(StoredContentDTO, _newContentDTO);
            }
            else
            {
                try
                {
                    _contentBLL.UpdateContent(_newContentDTO, StoredContentDTO.PathCover);
                    CurrentViewModel = _storedEditContentControlViewModel;
                    _storedEditContentControlViewModel.ErrorMessage = string.Empty;
                    _storedEditContentControlViewModel.SuccessMessage = "Edição concluída.";
                    await CloseWindow(1500);
                }
                catch(InvalidContentException ex)
                {
                    _storedEditContentControlViewModel.ErrorMessage = string.Empty;
                    CurrentViewModel = _storedEditContentControlViewModel;
                    _storedEditContentControlViewModel.ErrorMessage = ex.Message;
                }
            }
        }

        private async Task Cancel()
        {
            if (CurrentViewModel is EditContentControlViewModel)
                await CloseWindow(500);
            else
                CurrentViewModel = _storedEditContentControlViewModel;
        }


        private async Task CloseWindow(int delay)
        {
            await Task.Delay(delay);
            _closeWindow();
        }
    }
}
