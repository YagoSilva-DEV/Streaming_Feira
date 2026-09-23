using Streamall.Models.DTO;
using System.Windows.Navigation;

namespace Streamall.Views
{
    internal class HomeViewModel
    {
        private UserDTO userDTO;
        private NavigationService navigationService;

        public HomeViewModel(UserDTO userDTO, NavigationService navigationService)
        {
            this.userDTO = userDTO;
            this.navigationService = navigationService;
        }
    }
}