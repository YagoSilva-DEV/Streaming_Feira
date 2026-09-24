using Streamall.Models.DTO;
using System.Windows;
using System.Windows.Input;
using Streamall.Helpers;
using System.Linq;
using Streamall.ViewModels.Contents;
using Streamall.BLL.Services;
using Streamall.DAL.Repository;

namespace Streamall.Views.Modals
{
    public partial class ContentDetailsModal : Window
    {
        public ContentDetailsModal(ContentDTO contentDTO, UserDTO userDTO)
        {
            InitializeComponent();
            DataContext = new ContentDetailsViewModel(new UserServiceBLL(new UserRepositoryDAL()), contentDTO, userDTO);
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