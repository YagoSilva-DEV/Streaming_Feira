using Streamall.Models.DTO;
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
        void Navigate<TView>();
        void Navigate<TView>(UserDTO admDTO);
    }
}
