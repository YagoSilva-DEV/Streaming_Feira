using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels.Contents
{
    internal class EditContentModalViewModel
    {
        public ContentDTO ContentDTO { get; set; }
        private IContentBLL _contentBLL;
        private Action _closeWindow;
        public RelayCommand CloseWindowCommand { get; set; }
        public EditContentModalViewModel(ContentDTO contentDTO, IContentBLL contentBLL, Action closeWindow)
        {
            ContentDTO = contentDTO;
            _contentBLL = contentBLL;
            _closeWindow = closeWindow;

            CloseWindowCommand = new RelayCommand(execute => _closeWindow.Invoke());
        }
    }
}
