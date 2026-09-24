using Streamall.BLL.Services;
using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository;
using Streamall.DAL.Repository.Contents;
using Streamall.Models.DTO;
using Streamall.Models.Enums;
using Streamall.Navigation.Interface;
using Streamall.ViewModels;
using Streamall.ViewModels.Contents;
using Streamall.ViewModels.Users;
using Streamall.Views;
using Streamall.Views.Modals;
using Streamall.Views.UserControls;
using System.Linq;
using System.Windows;

namespace Streamall.Navigation.Service
{
    public class NavigationService : INavigationService
    {
        private AdministratorHomeViewModel _admViewModel;
        private ClientHomeViewModel _homeViewModel;        

        public void AddAdmViewModel(AdministratorHomeViewModel viewModel)
        {
            _admViewModel = viewModel;
        }

        public void AddHomeViewModel(ClientHomeViewModel viewModel)
        {
            _homeViewModel = viewModel;
        }
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
        public void Navigate<TView>(UserDTO userDTO)
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
                    owner.Opacity = 1;
            }
            if (typeof(TView) == typeof(AdministratorHome))
            {
                Window loginView = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);
                AdministratorHome admHome = new AdministratorHome(userDTO);
                admHome.WindowState = WindowState.Maximized;
                admHome.Show();
                loginView.Close();
            }
            if(typeof(TView) == typeof(Home))
            {
                Window loginView = Application.Current.Windows
                .OfType<Window>()
                .FirstOrDefault(w => w.IsActive);
                Home home = new Home(userDTO);
                home.WindowState = WindowState.Maximized;
                home.Show();
                loginView.Close();
            }

            
        }

        public void Navigate<TView>(ContentDTO contentDTO)
        {
            if (typeof(TView) == typeof(EditContentModal))
            {
                Window owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
                EditContentModal editContentModal = new EditContentModal(contentDTO);
                if (owner != null)
                {
                    editContentModal.Owner = owner;
                    editContentModal.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                    owner.Opacity = 0.3;
                }

                var editModalIsActive = editContentModal.ShowDialog();
                if (editModalIsActive == false)
                    owner.Opacity = 1;
            }
        }

        public bool ShowCatalogItemModal(CatalogItemType itemType)
        {
            Window owner = Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w.IsActive);
            var catalogModal = new AddCatalogItemModal(itemType);

            if(owner != null)
            {
                catalogModal.Owner = owner;
                catalogModal.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                owner.Opacity = 0.3;
            }

            var catalogModalIsActive = catalogModal.ShowDialog();
            if (catalogModalIsActive == false)
            {
                owner.Opacity = 1;
                return true;
            }
            else
                return false;
        }

        public void ViewModelNavigation<TViewModel>()
        {
            if (typeof(TViewModel) == typeof(ContentManagementViewModel))
            {
                _admViewModel.CurrentViewModel = new ContentManagementViewModel(new ContentServiceBLL(new ContentRepositoryDAL()), new NavigationService());
            }
            if (typeof(TViewModel) == typeof(InsertContentControlViewModel))
            {
                _admViewModel.CurrentViewModel = new InsertContentControlViewModel(new ContentServiceBLL(new ContentRepositoryDAL()), new NavigationService());
            }
            if(typeof(TViewModel) == typeof(ClientManagement))
            {
                _admViewModel.CurrentViewModel = new ClientManagementViewModel(new AdministratorServiceBLL(new AdministratorRepositoryDAL()));
            }
        }
    }
}
