using Streamall.BLL.Interfaces.Contents;
using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
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
        private EditContentControlViewModel _storedEditContentControlViewModel;
        private Action _closeWindow;
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

        public EditContentModalViewModel(ContentDTO contentDTO, Action closeWindow)
        {
            StoredContentDTO = contentDTO;
            SaveCommand = new RelayCommand(execute => Save());
            CancelCommand = new RelayCommand(execute => Cancel());
            CurrentViewModel = new EditContentControlViewModel(contentDTO, new ContentServiceBLL(new ContentRepositoryDAL()));
            _closeWindow = closeWindow;
        }

        private void Save()
        {
            if (CurrentViewModel is EditContentControlViewModel)
            {
                _storedEditContentControlViewModel = CurrentViewModel as EditContentControlViewModel;
                CurrentViewModel = new ConfirmEditContentViewModel(StoredContentDTO);
            }
        }

        private void Cancel()
        {
            if (CurrentViewModel is EditContentControlViewModel)
                _closeWindow.Invoke();
            else
                CurrentViewModel = _storedEditContentControlViewModel;
        }

    }
}
