using Streamall.Models.DTO;
using Streamall.Models.Enums;
using Streamall.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.Navigation.Interface
{
    public interface INavigationService
    {
        void AddAdmViewModel(AdministratorHomeViewModel administratorHomeViewModel);
        void Navigate<TView>();
        void Navigate<TView>(UserDTO admDTO);
        void Navigate<TView>(ContentDTO contentDTO);
        void ViewModelNavigation<TViewModel>();
        bool ShowCatalogItemModal(CatalogItemType itemType);
    }
}
