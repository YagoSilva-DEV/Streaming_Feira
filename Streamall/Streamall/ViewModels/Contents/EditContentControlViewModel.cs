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
    public class EditContentControlViewModel : ViewModelBase
    {
        public ContentDTO StoredContentDTO { get; set; }
        public ContentDTO NewContentDTO { get; set; }
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

        public RelayCommand OpenFileDialogCommand { get; set; }
        private string _contentType;
        public string ContentType
        {
            get
            {
                return _contentType;
            }
            set 
            {
                _contentType = value;
                OnPropertyChanged();
            }
        }
        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set 
            {
                _newName = value;
                OnPropertyChanged();
            }
        }

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        #region Imagem
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
                if (_fileMessage == null)
                    return "Nenhuma imagem selecionada";
                return string.Empty;
            }
            set
            {
                _fileMessage = value;
                OnPropertyChanged();
            }
        }
        #endregion
        public EditContentControlViewModel(ContentDTO contentDTO, IContentBLL contentBLL)
        {
            StoredContentDTO = contentDTO;
            _contentBLL = contentBLL;

            ContentType = (StoredContentDTO.ContentType == Models.Enums.ContentType.MOVIE) ? "Filme" : "Série";
            Genres = new List<GenreDTO>(_contentBLL.GetGenresDTO());
            FilmMakers = new List<FilmMakerDTO>(_contentBLL.GetFilmMakersDTO());
            OpenFileDialogCommand = new RelayCommand(execute => GetNewPathCover());
        }

        private void GetNewPathCover()
        {
            NewPathCover = FileDialogHelper.GetFilePath();
            FileMessage = NewPathCover;
        }
    }
}
