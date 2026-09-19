using Streamall.BLL.Interfaces.Contents;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.MVVM;
using Streamall.Navigation.Interface;
using Streamall.Views.Modals;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Streamall.ViewModels.Contents
{
    public class ContentManagementViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IContentBLL _contentBLL;
        private ObservableCollection<ContentDTO> _contents;

        public ObservableCollection<ContentDTO> Contents
        {
            get { return _contents; }
            set 
            { 
                _contents = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand RemoveContentCommand { get; set; }
        public RelayCommand EditContentCommand { get; set; }
        public ContentManagementViewModel(IContentBLL contentBLL, INavigationService navigationService)
        {
            _contentBLL = contentBLL;
            _navigationService = navigationService;

            Contents = new ObservableCollection<ContentDTO>(_contentBLL.GetContentDTOs());
            RemoveContentCommand = new RelayCommand(execute => RemoveContent(execute as ContentDTO));
            EditContentCommand = new RelayCommand(execute => EditContent(execute as ContentDTO));
        }

        private void RemoveContent(ContentDTO contentDTO)
        {
            int contentId = contentDTO.Id;

            try
            {
                _contentBLL.RemoveContent(contentId);
                Contents.Clear();
                Contents = new ObservableCollection<ContentDTO>(_contentBLL.GetContentDTOs());
            }
            catch (DataBaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void EditContent(ContentDTO contentDTO)
        {
            _navigationService.Navigate<EditContentModal>(contentDTO);
        }
    }
}
