using Streamall.BLL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.ViewModels.Contents
{
    public class ContentDetailsViewModel : ViewModelBase
    {
        private UserDTO _userDTO;
        private ContentDTO _contentDTO;
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


        public ContentDTO ContentDTO
        {
            get { return _contentDTO; }
            set { _contentDTO = value; }
        }

        private IUserBLL _userService;
        public RelayCommand AddFavoriteCommand { get; set; }

        public ContentDetailsViewModel(IUserBLL userBLL, ContentDTO contentDTO, UserDTO userDTO)
        {
            _userService = userBLL;
            ContentDTO = contentDTO;
            _userDTO = userDTO;
            AddFavoriteCommand = new RelayCommand(async execute => {await AddFavoriteContent(); });
        }

        private async Task AddFavoriteContent()
        {
            try
            {
                _userService.AddFavoriteContent(_contentDTO.Id, _userDTO.UserId);
                SuccessMessage = "Adicionado aos favoritos";
                await Task.Delay(1500);
                SuccessMessage = string.Empty;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
                await Task.Delay(1500);
                ErrorMessage = string.Empty;
            }
        }
    }
}
