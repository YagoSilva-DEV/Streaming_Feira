using Streamall.BLL.Interfaces.Contents;
using Streamall.Exceptions;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Enums;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels.Contents
{
    internal class AddCatalogItemModalViewModel : ViewModelBase
    {
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


        private string _toDo;

        public string ToDo
        {
            get { return _toDo; }
            set
            {
                _toDo = value;
                OnPropertyChanged();
            }
        }

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

        private string _fieldLabel;

        public string FieldLabel
        {
            get { return _fieldLabel; }
            set 
            { 
                _fieldLabel = value;
                OnPropertyChanged();
            }
        }

        private Action _closeWindow;
        private CatalogItemType _catalogItemType;
        private IGenreBLL _genreBLL;
        private IFilmMakerBLL _filmMakerBLL;
        public RelayCommand AddItemCommand { get; set; }
        public RelayCommand CancelCommand { get; set; }
        public AddCatalogItemModalViewModel(CatalogItemType catalogItemType, IGenreBLL genreBLL, IFilmMakerBLL filmMakerBLL, Action closeWindow)
        {
            if (catalogItemType == CatalogItemType.FILMMAKER)
            {
                ToDo = "Cadastro de cineastas";
                FieldLabel = "Insira o nome do cineasta:";
            }
            else
            {
                ToDo = "Cadastro de gêneros";
                FieldLabel = "Inisira o nome do gênero:";
            }
            _catalogItemType = catalogItemType;
            _genreBLL = genreBLL;
            _filmMakerBLL = filmMakerBLL;
            _closeWindow = closeWindow;

            AddItemCommand = new RelayCommand(async execute => { await AddItem(); });
            CancelCommand = new RelayCommand(execute => _closeWindow.Invoke());
        }

        private async Task AddItem()
        {
            ErrorMessage = string.Empty;
            SuccessMessage = string.Empty;

            try
            {
                if (_catalogItemType == CatalogItemType.FILMMAKER)
                {
                    _filmMakerBLL.InsertFilmMaker(new FilmMakerDTO(Name));
                    SuccessMessage = "Cineasta inserido com êxito";
                    await Task.Delay(1000);
                    _closeWindow.Invoke();
                }
                else
                {
                    _genreBLL.InsertGenre(new GenreDTO(Name));
                    SuccessMessage = "Gênero inserido com êxito";
                    await Task.Delay(2000);
                    _closeWindow.Invoke();
                }
            }

            catch (InvalidNameException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception)
            {
                ErrorMessage = "Ocorreu um erro inesperado.";
            }
        }
    }
}
