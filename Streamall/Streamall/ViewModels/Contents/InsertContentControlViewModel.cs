using Streamall.BLL.Interfaces.Contents;
using Streamall.Exceptions;
using Streamall.Helpers;
using Streamall.Models.DTO;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
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

		private ContentType _contentType;

		public ContentType ContentType
		{
			get { return _contentType; }
			set 
			{
				_contentType = value;
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

        private List<ContentType> _contentTypes;
        public List<ContentType> ContentTypes
        {
            get { return _contentTypes; }
            set
            {
                _contentTypes = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand OpenImageFileDialogCommand { get; set; }
        public RelayCommand InsertCommand { get; set; }
		private IContentBLL _contentBLL;
		public InsertContentControlViewModel(IContentBLL contentBLL)
		{
			_contentBLL = contentBLL;

            Genres = new List<GenreDTO>(_contentBLL.GetGenresDTO());
            FilmMakers = new List<FilmMakerDTO>(_contentBLL.GetFilmMakersDTO());
            ContentTypes = new List<ContentType>((ContentType[])Enum.GetValues(typeof(ContentType)));

            InsertCommand = new RelayCommand(execute => Insert());
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
				ContentDTO contentDTO = new ContentDTO(_name, _synopsis, _pathCover, _releaseDate, _genreDTO, _filmMaker, _contentType);
				_contentBLL.InsertContent(contentDTO);
			}
			catch(InvalidContentException ex)
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
    }
}
