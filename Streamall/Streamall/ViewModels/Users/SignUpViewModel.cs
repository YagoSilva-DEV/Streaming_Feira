using Streamall.BLL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Streamall.ViewModels
{
    public class SignUpViewModel : ViewModelBase
    {
        private IClientBLL _clientBLL;
        private Action _closeWindow;
        private string _fullName;

        public string FullName
        {
            get { return _fullName; }
            set
            {
                _fullName = value;
                OnPropertyChanged();
            }
        }

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

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged();
            }
        }

        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

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

        private string _successMessage;

        public string SuccessMessage
        {
            get { return _successMessage; }
            set
            {
                _successMessage = value;
                OnPropertyChanged();
            }
        }


        public RelayCommand SignUpCommand { get; set; }

        public SignUpViewModel(IClientBLL clientBLL, Action action)
        {
            _clientBLL = clientBLL;
            SignUpCommand = new RelayCommand(async execute => { await SignUp(execute as object); });
            _closeWindow = action;
        }

        private async Task SignUp(object pbPassword)
        {
            if (pbPassword is PasswordBox)
            {
                PasswordBox passwordBox = pbPassword as PasswordBox;
                _password = passwordBox.Password;
            }
                UserDTO user = new ClientDTO(_fullName, _userName, _password, _email);

            try
            {
                _clientBLL.SignUpAsClientBLL(user);
                ErrorMessage = string.Empty;
                SuccessMessage = "Cadastro concluído com êxito!";
                await Task.Delay(3000);
                _closeWindow.Invoke();
            }
            catch (InvalidSignUpException ex)
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
            catch (Exception)
            {
                ErrorMessage = "Ocorreu um erro inesperado.";
            }
        }
    }
}
