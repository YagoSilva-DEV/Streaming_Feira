
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.IO;
using Streamall.BLL.Services;
using Streamall.DAL.Repository;
using System.Windows;

namespace Streamall.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
        private readonly UserServiceBLL _userServiceBLL;
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

        public RelayCommand NextImageCommand => new RelayCommand(execute => NextImage());
        public RelayCommand PrevImageCommand => new RelayCommand(execute => PrevImage());

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
            _fullPathFiles = Directory.GetFiles(Path.Combine(AppContext.BaseDirectory, @"..\..\Assets"));
            ImageSourceFile = _fullPathFiles[_count];

            _userServiceBLL = new UserServiceBLL(new UserRepositoryDAL());
        }

        #region Métodos de Login, seja de cliente ou administrador
        private void EnterAsClient()
        {
            _user = new ClientDTO(_userName, _password, _userEmail);

            //chamar o método de login do cliente, passando o objeto _usuario como parâmetro
        }

        private void EnterAsAdmin()
        {
            _user = new AdministratorDTO(_userName, _password, _userEmail);
            //chamar o método de login do administrador, passando o objeto _usuario como parâmetro
        }
        #endregion

        #region Métodos de navegação de imagens para o carrossel
        private void NextImage()
        {
            _count = (_count == _fullPathFiles.Length - 1) ? 0 : _count + 1;
            ImageSourceFile = _fullPathFiles[_count];
        }

        private void PrevImage()
        {
            _count = (_count == 0) ? _fullPathFiles.Length - 1 : _count - 1;
            ImageSourceFile = _fullPathFiles[_count];
        }
        #endregion
        
    }
}
