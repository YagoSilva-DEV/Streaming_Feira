using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.Helpers
{
    public class MessageBoxHelper
    {
        public static void ShowMessageBoxSuccess(string message)
        {
            MessageBox.Show(message, "SUCESSO", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
