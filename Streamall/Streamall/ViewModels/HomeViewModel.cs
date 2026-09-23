using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System.Collections.ObjectModel;

namespace Streamall.ViewModels
{
    public class ClientHomeViewModel : ViewModelBase
    {
        private readonly IFilmeBLL _filmeBLL;

        // Propriedade para bindar o nome do usuário na tela
        private string _userName;
        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }

        private int _userId;
        public int UserId
        {
            get => _userId;
            set { _userId = value; OnPropertyChanged(); }
        }

       
    }
}