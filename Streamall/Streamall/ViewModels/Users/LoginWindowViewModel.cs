using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using Streamall.MVVM;
using Streamall.Navigation.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.ViewModels.Users
{
    internal class LoginWindowViewModel : ViewModelBase
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

        public LoginWindowViewModel(Action closeWindow)
        {
            try
            {
                CurrentViewModel = new LoginControlViewModel(new UserServiceBLL(new UserRepositoryDAL()), new NavigationService());
            }
            catch(IOException ex)
            {
                CurrentViewModel = new ErrorControlViewModel("Arquivos de imagens não foram encontrados", ex.Message, closeWindow);
            }
            catch(Exception)
            {
                CurrentViewModel = new ErrorControlViewModel("Erro inesperado", "Um erro inesperado ocorreu", closeWindow);
            }
        }
    }

}
