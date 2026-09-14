using Streamall.BLL.Services.Contents;
using Streamall.DAL.Repository.Contents;
using Streamall.ViewModels.Contents;
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

namespace Streamall.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ContentManagement.xaml
    /// </summary>
    public partial class ContentManagement : UserControl
    {
        public ContentManagement()
        {
            DataContext = new ContentManagementViewModel(new ContentServiceBLL(new ContentRepositoryDAL()));
            InitializeComponent();
        }
    }
}
