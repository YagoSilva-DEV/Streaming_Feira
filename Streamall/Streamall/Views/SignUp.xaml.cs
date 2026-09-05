using Streamall.ViewModels;
using System.Windows;

namespace Streamall.Views
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
            DataContext = new SignUpViewModel();
        }
    }
}
