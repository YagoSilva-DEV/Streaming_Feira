using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.MVVM;
using Streamall.ViewModels.Contents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamall.Navigation.Service;

namespace Streamall.ViewModels
{
    public class StartViewModel : ViewModelBase
    {
        public CarroselViewModel Carrosel { get; set; }

        public StartViewModel(IContentBLL contentBLL, UserDTO user)
        {
            Carrosel = new CarroselViewModel(contentBLL, user, new NavigationService());
        }
    }
}
