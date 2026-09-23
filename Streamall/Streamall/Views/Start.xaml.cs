using Streamall.BLL.Interfaces.Contents;
using System.Windows.Controls;
using Streamall.MVVM;
using Streamall.ViewModels.Contents;
using Streamall.ViewModels;

namespace Streamall.Views
{
    /// <summary>
    /// Interação lógica para Start.xam
    /// </summary>
    public partial class Start : Page
    {
        public Start(IContentBLL contentBLL)
        {
            InitializeComponent();
            DataContext = new StartViewModel(contentBLL);
        }
    }
}
