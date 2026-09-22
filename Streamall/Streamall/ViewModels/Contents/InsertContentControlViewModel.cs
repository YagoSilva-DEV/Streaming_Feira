using Streamall.BLL.Interfaces.Contents;
using Streamall.Exceptions;
using Streamall.Helpers;
using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using Streamall.MVVM;
using Streamall.Navigation.Interface;
using Streamall.Views.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Resources;

namespace Streamall.ViewModels.Contents
{
    public class InsertContentControlViewModel : ViewModelBase
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        private string _pathCover;

        public string PathCover
        {
            get { return _pathCover; }
            set
            {
                _pathCover = value;
                OnPropertyChanged();
            }
        }

        private GenreDTO _genreDTO;

        public GenreDTO GenreDTO
        {
            get { return _genreDTO; }
            set
            {
                _genreDTO = value;
                OnPropertyChanged();
            }
        }

        private FilmMakerDTO _filmMaker;

        public FilmMakerDTO FilmMaker
        {
            get { return _filmMaker; }
            set
            {
                _filmMaker = value;
                OnPropertyChanged();
            }
        }

        private DateTime _releaseDate;

        public DateTime ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                _releaseDate = value;
                OnPropertyChanged();
            }
        }

        private string _synopsis;

        public string Synopsis
        {
            get { return _synopsis; }
            set
            {
                _synopsis = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;

        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }

        private string _successMessage;

        public string SuccessMessage
        {
            get { return _successMessage; }
            set
            {
                _successMessage = value;
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

        private ObservableCollection<GenreDTO> _genres;
        public ObservableCollection<GenreDTO> Genres
        {
            get { return _genres; }
            set
            {
                _genres = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<FilmMakerDTO> _filmMakers;
        public ObservableCollection<FilmMakerDTO> FilmMakers
        {
            get { return _filmMakers; }
            set
            {
                _filmMakers = value;
                OnPropertyChanged();
            }
        }
        private INavigationService _navigationService;
        public RelayCommand OpenImageFileDialogCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
        public RelayCommand AddGenreCommand { get; set; }
        public RelayCommand AddFilmMakerCommand { get; set; }
        private IContentBLL _contentBLL;
        public InsertContentControlViewModel(IContentBLL contentBLL, INavigationService navigationService)
        {
            _contentBLL = contentBLL;
            _navigationService = navigationService;
            ReleaseDate = DateTime.Today;
            Genres = new ObservableCollection<GenreDTO>(_contentBLL.GetGenresDTO());
            FilmMakers = new ObservableCollection<FilmMakerDTO>(_contentBLL.GetFilmMakersDTO());

            InsertCommand = new RelayCommand(execute => Insert());
            AddGenreCommand = new RelayCommand(execute => AddGenre());
            AddFilmMakerCommand = new RelayCommand(execute => AddFilmMaker());
            OpenImageFileDialogCommand = new RelayCommand(execute => GetNewPathCover());
        }

        private void GetNewPathCover()
        {
            PathCover = FileDialogHelper.GetFilePath();
            FileMessage = PathCover;
        }


        private void Insert()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;
            try
            {
                ContentDTO contentDTO = new ContentDTO(_name, _synopsis, _pathCover, _releaseDate, _genreDTO, _filmMaker, ContentType.MOVIE);
                _contentBLL.InsertContent(contentDTO);
                SuccessMessage = "Conteúdo salvo com êxito.";
                LimparCampos();
            }
            catch (InvalidContentException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception)
            {
                ErrorMessage = "Um erro inesperado ocorreu.";
            }
        }

        private void LimparCampos()
        {
            Name = string.Empty;
            Synopsis = string.Empty;
            PathCover = string.Empty;
            ReleaseDate = DateTime.Today;
            GenreDTO = null;
            FilmMaker = null;
        }

        private void AddGenre()
        {
            if (_navigationService.ShowCatalogItemModal(CatalogItemType.GENRE))
            {
                FilmMakers.Clear();
                Genres = new ObservableCollection<GenreDTO>(_contentBLL.GetGenresDTO());
            }
        }

        private void AddFilmMaker()
        {
            if (_navigationService.ShowCatalogItemModal(CatalogItemType.FILMMAKER))
            {
                FilmMakers.Clear();
                FilmMakers = new ObservableCollection<FilmMakerDTO>(_contentBLL.GetFilmMakersDTO());
            }
        }
    }
}
