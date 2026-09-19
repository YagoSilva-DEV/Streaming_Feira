using Streamall.BLL.Interfaces.Contents;
using Streamall.Helpers;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels.Contents
{
    internal class EditContentModalViewModel : ViewModelBase
    {
        public ContentDTO ContentDTO { get; set; }
        private IContentBLL _contentBLL;
        private Action _closeWindow;
        public RelayCommand CloseWindowCommand { get; set; }
        public RelayCommand OpenFileDialogCommand { get; set; }
        private string _newPathCover;

        public string NewPathCover
        {
            get { return _newPathCover; }
            set 
            { 
                _newPathCover = value;
                OnPropertyChanged();
            }
        }
        private string _fileMessage;
        public string FileMessage
        {
            get
            {
                return _fileMessage;
            }
            set
            {
                _fileMessage = value;
                OnPropertyChanged();
            }
        }

        public EditContentModalViewModel(ContentDTO contentDTO, IContentBLL contentBLL, Action closeWindow)
        {
            ContentDTO = contentDTO;
            _contentBLL = contentBLL;
            _closeWindow = closeWindow;

            CloseWindowCommand = new RelayCommand(execute => _closeWindow.Invoke());
            OpenFileDialogCommand = new RelayCommand(execute => GetNewPathCover());
        }

        private void GetNewPathCover()
        {
            NewPathCover = FileDialogHelper.GetFilePath();
            FileMessage = (NewPathCover != null) ? string.Empty : "Nenhum arquivo selecionado";
        }
    }
}
