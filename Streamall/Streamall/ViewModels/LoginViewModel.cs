
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.IO;

namespace Streamall.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
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

        private string _emailUser;

        public string EmailUser
        {
            get { return _emailUser; }
            set 
            { 
                _emailUser = value;
                OnPropertyChanged();
            }
        }

        private string _senha;

        public string Senha
        {
            get { return _senha; }
            set 
            {
                _senha = value;
                OnPropertyChanged();
            }
        }

        private UsuarioDTO _user;

        public RelayCommand EnterAsClientCommand => new RelayCommand(execute => EnterAsClient());
        public RelayCommand EnterAsAdminCommand => new RelayCommand(execute => EnterAsAdmin());

        #endregion
        public LoginViewModel()
        {
            _fullPathFiles = Directory.GetFiles(Path.Combine(AppContext.BaseDirectory, @"..\..\Assets"));
            ImageSourceFile = _fullPathFiles[_count];
        }

        #region Métodos de Login, seja de cliente ou administrador
        private void EnterAsClient()
        {
            _user = new ClienteDTO(_userName, _senha, _emailUser);

            //chamar o método de login do cliente, passando o objeto _usuario como parâmetro
        }

        private void EnterAsAdmin()
        {
            _user = new AdiministradorDTO(_userName, _senha, _emailUser);
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
