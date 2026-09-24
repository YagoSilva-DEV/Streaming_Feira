using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using Streamall.Models.DTO;
using Streamall.Views.Modals;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


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
        private void ScrollFeatured_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is ScrollViewer scrollViewer)
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    double middleOffset =
                        (scrollViewer.ExtentWidth - scrollViewer.ViewportWidth) / 2;

                    if (middleOffset > 0)
                        scrollViewer.ScrollToHorizontalOffset(middleOffset);

                }), System.Windows.Threading.DispatcherPriority.Loaded);
            }
        }

    }
}
