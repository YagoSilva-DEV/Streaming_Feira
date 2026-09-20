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

        #region Atributos para a edição do conteudo
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

        private GenreDTO _newGenre;
        public GenreDTO NewGenre
        {
            get { return _newGenre; }
            set
            {
                _newGenre = value;
                OnPropertyChanged();
            }
        }

        private FilmMakerDTO _newFilmMaker;
        public FilmMakerDTO NewFilmMaker
        {
            get { return _newFilmMaker; }
            set
            {
                _newFilmMaker = value;
                OnPropertyChanged();
            }
        }

        private string _newSynopsis;
        public string NewSynopsis
        {
            get { return _newSynopsis; }
            set
            {
                _newSynopsis = value;
                OnPropertyChanged();
            }
        }

        private DateTime _newReleaseDate;
        public DateTime NewReleaseDate
        {
            get { return _newReleaseDate; }
            set
            {
                _newReleaseDate = value;
                OnPropertyChanged();
            }
        }

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
        #endregion

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
        public EditContentControlViewModel(ContentDTO contentDTO, IContentBLL contentBLL)
        {
            StoredContentDTO = contentDTO;
            _contentBLL = contentBLL;

            ContentType = (StoredContentDTO.ContentType == Models.Enums.ContentType.MOVIE) ? "Filme" : "Série";
            NewReleaseDate = DateTime.Today;
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
