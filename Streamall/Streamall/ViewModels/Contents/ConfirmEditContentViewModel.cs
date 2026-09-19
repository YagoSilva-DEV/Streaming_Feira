using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.ViewModels.Contents
{
    public class ConfirmEditContentViewModel : ViewModelBase
    {
        public ContentDTO OldContentDTO { get; set; }
        private string _oldContentType;
        public string OldContentType {
            get
            {
                return _oldContentType;
            }
            set
            {
                _oldContentType = value;
                OnPropertyChanged();
            }
        }
        public ConfirmEditContentViewModel(ContentDTO oldContentDTO)
        {
            OldContentDTO = oldContentDTO;
            OldContentType = (OldContentDTO.ContentType == Models.Enums.ContentType.MOVIE) ? "Filme" : "Série";
        }
    }
}
