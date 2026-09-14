using Streamall.Models.DTO;
using Streamall.Navigation.Interface;
using Streamall.ViewModels;
using Streamall.Views;
using System.Linq;
using System.Windows;

namespace Streamall.Navigation.Service
{
    public class NavigationService : INavigationService
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
            if (typeof(TView) == typeof(AdministratorHome))
            {
                Window loginView = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);

                AdministratorHome admHome = new AdministratorHome();
                admHome.WindowState = WindowState.Maximized;
                admHome.Show();
                loginView.Close();
            }
        }
        public void Navigate<TView>(UserDTO admDTO)
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
            if (typeof(TView) == typeof(AdministratorHome))
            {
                Window loginView = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);
                AdministratorHome admHome = new AdministratorHome(admDTO);
                admHome.WindowState = WindowState.Maximized;
                admHome.Show();
                loginView.Close();
            }
        }
    }
}
