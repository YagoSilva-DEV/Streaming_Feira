using Streamall.Models.DTO;
using System.Windows;
using System.Windows.Input;

namespace Streamall.Views.Modals
{
    public partial class ContentDetailsModal : Window
    {
        public ContentDetailsModal(ContentDTO contentDTO)
        {
            InitializeComponent();
            DataContext = contentDTO;
        }

        private void Header_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}