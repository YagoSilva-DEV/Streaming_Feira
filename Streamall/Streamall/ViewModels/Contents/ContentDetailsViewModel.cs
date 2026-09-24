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
    public class ContentDetailsViewModel
    {
        private UserDTO _userDTO;
        private ContentDTO _contentDTO;

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
            AddFavoriteCommand = new RelayCommand(execute => AddFavoriteContent());
        }

        private void AddFavoriteContent()
        {
            try
            {
                _userService.AddFavoriteContent(_contentDTO.Id, _userDTO.UserId);
                MessageBox.Show("tudo certo");
            }
            catch (DataBaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
