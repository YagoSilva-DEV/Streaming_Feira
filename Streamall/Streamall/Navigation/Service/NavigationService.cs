using Streamall.Navigation.Interface;
using Streamall.ViewModels;
using Streamall.Views;
using System.Linq;
using System.Windows;

namespace Streamall.Navigation.Service
{
    internal class NavigationService : INavigationService
    {
        public void Navigate<TView>()
        {
            if (typeof(TView) == typeof(SignUp))
            {
                Window owner = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);

                SignUp signUp = new SignUp();

                if (owner != null)
                {
                    signUp.Owner = owner;
                    signUp.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    owner.Opacity = 0.3;
                }


                var signUpIsActive = signUp.ShowDialog();

                if (signUpIsActive == false)
                {
                    owner.Opacity = 1;
                }
            }
        }
    }
}
