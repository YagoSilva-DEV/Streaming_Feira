using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using System.Windows;
using System.Windows.Controls;


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
    }
}
