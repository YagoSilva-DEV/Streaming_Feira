using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Streamall.Models.DTO;
using Streamall.Views.Modals;


namespace Streamall.Views.UserControls
{
    /// <summary>
    /// Interação lógica para Carousel.xam
    /// </summary>
    public partial class Carousel : UserControl
    {
        public Carousel()
        {
            InitializeComponent();
            //DataContext = new CarroselViewModel(new ContentServiceBLL(new ContentRepositoryDAL()));
        }

        private void ScrollLeft_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button &&
                button.Tag is ScrollViewer scroll)
            {
                scroll.ScrollToHorizontalOffset(
                    scroll.HorizontalOffset - 240);
            }
        }

        private void ScrollRight_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button &&
                button.Tag is ScrollViewer scroll)
            {
                scroll.ScrollToHorizontalOffset(
                    scroll.HorizontalOffset + 240);
            }
        }

        private void MainScroll_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            MainScroll.ScrollToVerticalOffset(MainScroll.VerticalOffset - e.Delta);
            e.Handled = true;
        }

        private void Content_Click(object sender, MouseButtonEventArgs e)
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

            ContentDetailsModal detailsWindow = new ContentDetailsModal(contentDTO);

            Window ownerWindow = Window.GetWindow(this);

            if (ownerWindow != null)
            {
                detailsWindow.Owner = ownerWindow;
            }

            detailsWindow.ShowDialog();
        }
    }
}
