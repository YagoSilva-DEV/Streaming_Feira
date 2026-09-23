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

        // Propriedade para bindar o nome do usuário na tela
        private string _userName;
        private INavigationService _navigationService;

        public string UserName
        {
            get => _userName;
            set { _userName = value; OnPropertyChanged(); }
        }

        public ClientHomeViewModel(UserDTO userDTO, INavigationService navigationService)
        {
            _navigationService = navigationService;
            // _navigationService.AddHomeViewModel(this); se necessario
                UserName = userDTO.UserName;
        }

    }
}