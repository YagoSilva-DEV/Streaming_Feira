
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.IO;
using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using Streamall.Exceptions;

namespace Streamall.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
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

        private readonly ClientServiceBLL _clientServiceBLL;
        private readonly AdministratorServiceBLL _administratorServiceBLL;
        #region Carrossel de imagens na tela de login
        private int _count = 0;
        private string _imageSourceFile;
        public string ImageSourceFile
        {
            get { return _imageSourceFile; }
            set
            {
                _imageSourceFile = value;
                OnPropertyChanged();
            }
        }
        private string[] _fullPathFiles;
        #endregion

        #region Criação dos atributos necessários para o login do usuário
        private string _userName;

        public string UserName
        {
            get { return _userName; }
            set 
            { 
                _userName = value;
                OnPropertyChanged();
            }
        }

        private string _userEmail;

        public string UserEmail
        {
            get { return _userEmail; }
            set 
            { 
                _userEmail = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password ; }
            set 
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private UserDTO _user;

        public RelayCommand EnterAsClientCommand => new RelayCommand(execute => EnterAsClient());
        public RelayCommand EnterAsAdminCommand => new RelayCommand(execute => EnterAsAdmin());

        #endregion
        public LoginViewModel()
        {
            _fullPathFiles = Directory.GetFiles(AppContext.BaseDirectory + @"..\..\Assets").OrderBy(f => Guid.NewGuid()).Take(10).ToArray();//Pega apenas 10 arquivos da Assets
            _clientServiceBLL = new ClientServiceBLL(new ClientRepositoryDAL());
            _administratorServiceBLL = new AdministratorServiceBLL(new AdministratorRepositoryDAL());
            ImageSourceFile = _fullPathFiles[_count];

            _ = CarouselImageReplace();
        }


        #region Métodos de Login, seja de cliente ou administrador
        private void EnterAsClient()
        {
            _user = new ClientDTO(_userName, _password, _userEmail);

            try
            {
                _clientServiceBLL.EnterAsClientBLL(_user);
                MessageBox.Show("Login realizado com sucesso!");
                ErrorMessage = string.Empty;
            }
            catch (InvalidLoginException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        private void EnterAsAdmin()
        {
            _user = new AdministratorDTO(_userName, _password, _userEmail);
            try
            {
                _administratorServiceBLL.EnterAsAdministratorBLL(_user);

                MessageBox.Show("Login realizado com sucesso!");
                ErrorMessage = string.Empty;
            }
            catch(InvalidLoginException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
        #endregion

        #region Métodos de navegação de imagens para o carrossel
        private async Task CarouselImageReplace()
        {
            while (true)
            {
                await Task.Delay(3000);
                _count = (_count == _fullPathFiles.Length - 1) ? 0 : _count + 1;

                ImageSourceFile = _fullPathFiles[_count];
            }
        }
        #endregion
        
    }
}
