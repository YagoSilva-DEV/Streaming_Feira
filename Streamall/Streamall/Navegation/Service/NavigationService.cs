using Streamall.Interface;
using Streamall.ViewModels;
using Streamall.Views;
using System.Linq;
using System.Windows;

namespace Streamall.Service
{
    internal class NavigationService : INavegationService
    {
        public void Navigate<TViewModel>()
        {
            if (typeof(TViewModel) == typeof(SignUpViewModel))
            {
                Window owner = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);

                SignUp signUp = new SignUp();

                if (owner != null)
                {
                    signUp.Owner = owner;
                    signUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                }


                signUp.ShowDialog();
            }
        }
    }
}
