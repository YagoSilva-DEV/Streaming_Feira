using Streamall.Interface;
using Streamall.ViewModels;
using Streamall.Views;

namespace Streamall.Service
{
    internal class NavegationService : INavegationService
    {
        public void Navigate<TViewModel>()
        {
            if(typeof(TViewModel) == typeof(SignUpViewModel))
            {
                new SignUp().ShowDialog();
            }
        }
    }
}
