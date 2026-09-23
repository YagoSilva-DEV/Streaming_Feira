using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using Streamall.MVVM;
using Streamall.Navigation.Interface;
using System.Collections.ObjectModel;

namespace Streamall.ViewModels
{
    public class ClientHomeViewModel : ViewModelBase
    {

        private string _userName;
        private readonly INavigationService _navigationService;

        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }

        public ClientHomeViewModel(UserDTO userDTO, INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Atribuição das propriedades vindas do DTO
            UserName = userDTO.UserName;
        }

    }
}