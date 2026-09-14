using Streamall.BLL.Interfaces.Contents;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels.Contents
{
    internal class ContentManagementViewModel : ViewModelBase
    {
		private readonly IContentBLL _contentBLL;
		public ObservableCollection<ContentDTO> Contents { get; set; }


		public ContentManagementViewModel(IContentBLL contentBLL)
		{
			_contentBLL = contentBLL;

			Contents = new ObservableCollection<ContentDTO>(_contentBLL.GetContentDTOs());
		}
	}
}
