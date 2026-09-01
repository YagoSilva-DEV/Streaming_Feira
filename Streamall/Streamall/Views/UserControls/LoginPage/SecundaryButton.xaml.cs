using Streamall.MVVM;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Streamall.Views.UserControls.LoginPage
{
    public partial class SecundaryButton : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string _buttonContent;

        public string ButtonContent
        {
            get { return _buttonContent; }
            set 
            { 
                _buttonContent = value;
                OnPropertyChanged();
            }
        }

        public SecundaryButton()
        {
            InitializeComponent();
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
