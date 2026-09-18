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
	public class ContentManagementViewModel : ViewModelBase
    {
		private readonly IContentBLL _contentBLL;
		public ObservableCollection<ContentDTO> Contents { get; set; }
        public RelayCommand RemoveContentCommand { get; set; }
        public RelayCommand EditContentCommand { get; set; }
        public ContentManagementViewModel(IContentBLL contentBLL)
		{
			_contentBLL = contentBLL;

			Contents = new ObservableCollection<ContentDTO>(_contentBLL.GetContentDTOs());
			RemoveContentCommand = new RelayCommand(execute => RemoveContent(execute as ContentDTO));
			EditContentCommand = new RelayCommand(execute => EditContent(execute as ContentDTO));
		}

		private void RemoveContent(ContentDTO contentDTO)
		{
			int contentId = contentDTO.Id;

			//chamar método para excluir o conteúdo.
		}
        private void EditContent(ContentDTO contentDTO)
        {
            int contentId = contentDTO.Id;

            //chamar método para editar o conteúdo.
        }
    }
}
