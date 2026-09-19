using Streamall.BLL.Interfaces.Contents;
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
    internal class EditContentModalViewModel : ViewModelBase
    {
        public ContentDTO ContentDTO { get; set; }
        private IContentBLL _contentBLL;
        private List<GenreDTO> _genres;
        public List<GenreDTO> Genres
        {
            get { return _genres; }
            set 
            { 
                _genres = value;
                OnPropertyChanged();
            }
        }
        private List<FilmMakerDTO> _filmMakers;

        public List<FilmMakerDTO> FilmMakers
        {
            get { return _filmMakers; }
            set 
            {
                _filmMakers = value;
                OnPropertyChanged();
            }
        }


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
                if(_fileMessage == null)
                    return "Nenhuma imagem selecionada";
                return string.Empty;
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

            Genres = new List<GenreDTO>(_contentBLL.GetGenresDTO());
            FilmMakers = new List<FilmMakerDTO>(_contentBLL.GetFilmMakersDTO());

            CloseWindowCommand = new RelayCommand(execute => _closeWindow.Invoke());
            OpenFileDialogCommand = new RelayCommand(execute => GetNewPathCover());
        }

        private void GetNewPathCover()
        {
            NewPathCover = FileDialogHelper.GetFilePath();
            FileMessage = NewPathCover;
        }
    }
}
