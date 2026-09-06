
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
using Streamall.Interface;
using System.Threading;
using Streamall.Views;

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

        private INavegationService _navegationService;
        private readonly IClientBLL _clientServiceBLL;
        private readonly IAdministratorBLL _administratorServiceBLL;
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

        public RelayCommand EnterAsClientCommand { get; set; }
        public RelayCommand EnterAsAdminCommand { get; set; }
        public RelayCommand NavigateToSignUpCommand { get; set; }

        public LoginViewModel(IClientBLL clientServiceBLL, IAdministratorBLL administratorServiceBLL, INavegationService navegationService)
        {
            _fullPathFiles = Directory.GetFiles(AppContext.BaseDirectory + @"..\..\Assets").OrderBy(f => Guid.NewGuid()).Take(10).ToArray();//Pega apenas 10 arquivos da Assets
            _clientServiceBLL = clientServiceBLL;
            _administratorServiceBLL = administratorServiceBLL;
            _navegationService = navegationService;
            ImageSourceFile = _fullPathFiles[_count];

            _ = CarouselImageReplace();

            EnterAsClientCommand = new RelayCommand(execute => EnterAsClient());
            EnterAsAdminCommand = new RelayCommand(execute => EnterAsAdmin());
            NavigateToSignUpCommand = new RelayCommand(execute => _navegationService.Navigate<SignUpViewModel>());
        }

        #region Métodos de Login, seja de cliente ou administrador
        private void EnterAsClient()
        {
            UserDTO _user = new ClientDTO(_userName, _password, _userEmail);

            ExecuteLogin(() =>
            {
                _clientServiceBLL.EnterAsClientBLL(_user);
            });
        }

        private void EnterAsAdmin()
        {
            UserDTO _user = new AdministratorDTO(_userName, _password, _userEmail);
            ExecuteLogin(() =>
            {
                _administratorServiceBLL.EnterAsAdministratorBLL(_user);
            });
        }

        private void ExecuteLogin(Action loginAction)
        {
            try
            {
                loginAction();
                ErrorMessage = string.Empty;
                MessageBox.Show("Login realizado com sucesso!");
            }
            catch (InvalidLoginException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (DataBaseException ex)
            {
                ErrorMessage = ex.Message;
            }
            catch (Exception)
            {
                ErrorMessage = "Ocorreu um erro inesperado.";
            }
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
