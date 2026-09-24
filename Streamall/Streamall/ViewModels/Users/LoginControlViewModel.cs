
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.IO;
using Streamall.DAL.Repository;
using System.Windows;
using System.Linq;
using System.Threading.Tasks;
using Streamall.Exceptions;
using Streamall.BLL.Interfaces;
using Streamall.Navigation.Interface;
using System.Threading;
using Streamall.Models.Enums;
using Streamall.Views;
using System.Windows.Controls;

namespace Streamall.ViewModels
{
    public class LoginControlViewModel : ViewModelBase
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

        private INavigationService _navigationService;
        private IUserBLL _userBLL;
        private readonly CancellationTokenSource _carouselCancellationTokenSource = new CancellationTokenSource();
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
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public RelayCommand LoginCommand { get; set; }
        public RelayCommand NavigateToSignUpCommand { get; set; }

        public LoginControlViewModel(IUserBLL userBLL, INavigationService navegationService)
        {
            string assetsPaths = Path.Combine(AppContext.BaseDirectory, @"..\..\Assets");
            string[] pathFile = Directory.GetFiles(assetsPaths).OrderBy(f => Guid.NewGuid()).Take(10).ToArray();
            _fullPathFiles = new string[pathFile.Length];
            for (int i = 0; i < pathFile.Length; i++)
            {
                if (File.Exists(pathFile[i]))
                {
                    _fullPathFiles[i] = pathFile[i];
                }
            }
            //Pega apenas 10 arquivos da Assets
            _userBLL = userBLL;
            _navigationService = navegationService;
            ImageSourceFile = _fullPathFiles[_count];

            _ = CarouselImageReplace();

            LoginCommand = new RelayCommand(execute => Login(execute as object));
            NavigateToSignUpCommand = new RelayCommand(execute => _navigationService.Navigate<SignUp>());
        }

        #region Métodos de Login, seja de cliente ou administrador
        private void Login(object pbPassword)
        {
            if (pbPassword is PasswordBox)
            {
                PasswordBox passwordBox = pbPassword as PasswordBox;
                _password = passwordBox.Password;
            }
            UserDTO userDTO = new UserDTO(_userName, _password, _userEmail);

            try
            {
                ErrorMessage = string.Empty;
                UserDTO userData = _userBLL.LoginBLL(userDTO);
                _userBLL.KeepUserActive(userData.UserId);
                if (userData.UserType == UserType.ADMINISTRATOR)
                {
                    _navigationService.Navigate<AdministratorHome>(userData);
                }
                else
                {
                    UserDTO clientDTO = userData as ClientDTO;
                    _userBLL.KeepUserActive(userData.UserId);
                    _navigationService.Navigate<Home>(userData);
                }
            }
            catch (InvalidLoginException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (InvalidEmailException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (InvalidPasswordException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
            }
            /*
            catch (Exception)
            {
                ErrorMessage = "Ocorreu um erro inesperado!";
            }
            */
        }
        #endregion

        #region Método de navegação de imagens para o carrossel
        private async Task CarouselImageReplace()
        {
            while (!_carouselCancellationTokenSource.Token.IsCancellationRequested)
            {
                await Task.Delay(4500);
                _count = (_count + 1) % _fullPathFiles.Length;

                ImageSourceFile = _fullPathFiles[_count];
            }
        }
        #endregion

    }
}
