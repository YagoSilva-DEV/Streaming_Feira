using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.Interface
{
    internal interface INavegationService
    {
        void Navigate<TViewModel>();
    }
}
