using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;

namespace Streamall.ViewModels
{
    internal class LoginViewModel : ViewModelBase
    {
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

        public LoginViewModel()
        {
            _fullPathFiles = Directory.GetFiles(Path.Combine(AppContext.BaseDirectory, @"..\..\Assets"));
            ImageSourceFile = _fullPathFiles[_count];
        }

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


    }
}
