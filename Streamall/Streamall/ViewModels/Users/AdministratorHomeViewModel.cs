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
using Streamall.Navigation.Service;
using System.IO;
using Streamall.Views.UserControls;
using Streamall.BLL.Interfaces;

namespace Streamall.ViewModels.Users
{
    public class AdministratorHomeViewModel : ViewModelBase
    {
        private IUserBLL _userService;
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
        private Action _closeWindow;
        private INavigationService _navigationService;
        public RelayCommand InsertContentControlCommand { get; set; }
        public RelayCommand ShowContentsManagmentCommand { get; set; }
        public RelayCommand ShowClientManagementCommand { get; set; }
        public RelayCommand CloseWindowCommand { get; set; }
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
        public AdministratorHomeViewModel(UserDTO admDTO, INavigationService navigationService, Action closeWindow, IUserBLL userBLL)
        {
            try
            {
                Adm = admDTO;
                CurrentViewModel = new ContentManagementViewModel(new ContentServiceBLL(new ContentRepositoryDAL()), new NavigationService());
                _navigationService = navigationService;
                _navigationService.AddAdmViewModel(this);
                _closeWindow = closeWindow;
                _userService = userBLL;
                CloseWindowCommand = new RelayCommand(async execute => { await CloseWindow(); });
                InsertContentControlCommand = new RelayCommand(execute => _navigationService.ViewModelNavigation<InsertContentControlViewModel>());
                ShowContentsManagmentCommand = new RelayCommand(execute => _navigationService.ViewModelNavigation<ContentManagementViewModel>());
                ShowClientManagementCommand = new RelayCommand(execute => _navigationService.ViewModelNavigation<ClientManagement>());
            }
            catch (Exception)
            {
                CurrentViewModel = new ErrorControlViewModel("Erro insperado", "Ocorreu um erro inesperdo", _closeWindow);
            }
        }

        private async Task CloseWindow()
        {
            _userService.KeepUserInactive(Adm.UserId);
            await Task.Delay(250);
            _closeWindow.Invoke();
        }
    }
}
