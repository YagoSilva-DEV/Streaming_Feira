using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Streamall.Models.DTO;
using Streamall.Views.Modals;

namespace Streamall.Views
{
    /// <summary>
    /// Interação lógica para Pesquisa.xam
    /// </summary>
    public partial class Pesquisa : Page
    {
        public Pesquisa()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;

            if (element == null)
            {
                return;
            }

            ContentDTO contentDTO = element.DataContext as ContentDTO;

            if (contentDTO == null)
            {
                return;
            }
            /*
            //ContentDetailsModal detailsWindow = new ContentDetailsModal(contentDTO);

            Window ownerWindow = Window.GetWindow(this);

            if (ownerWindow != null)
            {
                detailsWindow.Owner = ownerWindow;
            }

            detailsWindow.ShowDialog();
            */
        }
    }
}
