using Streamall.BLL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Streamall.ViewModels.Users
{
    public class ClientManagementViewModel : ViewModelBase
    {
        private IAdministratorBLL _administratorService;
        private List<ClientDTO> _clientsList;
        private ObservableCollection<ClientDTO> _clients;
        public ObservableCollection<ClientDTO> Clients
        {
            get { return _clients; }
            set 
            { 
                _clients = value;
                OnPropertyChanged();
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set 
            {
                _searchText = value;
                OnPropertyChanged();
                SearchClient(_searchText);
            }
        }


        public RelayCommand RemoveClientCommand { get; set; }

        public ClientManagementViewModel(IAdministratorBLL administratorBLL)
        {
            _administratorService = administratorBLL;
            _clientsList = new List<ClientDTO>(_administratorService.GetClientDTOs());
            RemoveClientCommand = new RelayCommand(execute => RemoveClient(execute as ClientDTO));

            Clients = new ObservableCollection<ClientDTO>(_clientsList);
        }

        private void RemoveClient(ClientDTO clientDTO)
        {
            try
            {
                _administratorService.RemoveClient(clientDTO.UserId);
                _clientsList = new List<ClientDTO>(_administratorService.GetClientDTOs());
                Clients = new ObservableCollection<ClientDTO>(_clientsList);
            }
            catch(DataBaseException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SearchClient(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                Clients = new ObservableCollection<ClientDTO>(_clients.Where(c => c.FullName.StartsWith(name, StringComparison.OrdinalIgnoreCase) || c.UserName.StartsWith(name, StringComparison.OrdinalIgnoreCase)));
            else
                Clients = new ObservableCollection<ClientDTO>(_clientsList);
        }
    }
}
