using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.Navigation.Interface
{
    internal interface INavigationService
    {
        void Navigate<TViewModel>();
    }
}
