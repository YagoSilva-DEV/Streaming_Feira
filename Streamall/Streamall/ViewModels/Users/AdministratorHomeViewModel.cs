using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Streamall.ViewModels.Contents;
using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using Streamall.Navigation.Interface;

namespace Streamall.ViewModels.Users
{
    public class AdministratorHomeViewModel : ViewModelBase
    {
        private object _currentViewModel;
        public object CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged();
            }
        }

        private INavigationService _navigationService;

        public RelayCommand ShowContentsManagmentCommand { get; set; }

        public UserDTO Adm { get; set; }
        public string NameInitials
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Adm.FullName))
                    return "";

                var parts = Adm.FullName.Trim().Split(' ');

                if (parts.Length == 1)
                    return parts[0][0].ToString().ToUpper();

                return $"{parts[0][0]}{parts[parts.Length - 1][0]}".ToUpper();
            }
        }
        public string FullNameAdm
        {
            get
            {
                return Adm.FullName;
            }
        }

        public AdministratorHomeViewModel()
        {
        }
        public AdministratorHomeViewModel(UserDTO admDTO, INavigationService navigationService)
        {
            Adm = admDTO;
            _navigationService = navigationService;
            _navigationService.AddAdmViewModel(this);
            ShowContentsManagmentCommand = new RelayCommand(canExecute => _navigationService.ViewModelNavigation<ContentManagementViewModel>());
        }
    }
}
