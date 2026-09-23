using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.MVVM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.ViewModels.Users
{
    public class ClientManagementViewModel : ViewModelBase
    {
        private IAdministratorBLL _administratorService;
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

        public RelayCommand RemoveClientCommand { get; set; }

        public ClientManagementViewModel(IAdministratorBLL administratorBLL)
        {
            _administratorService = administratorBLL;
            Clients = new ObservableCollection<ClientDTO>(_administratorService.GetClientDTOs());
            RemoveClientCommand = new RelayCommand(execute => RemoveClient(execute as ClientDTO));
        }

        private void RemoveClient(ClientDTO clientDTO)
        {
            //código para remover o cliente
        }
    }
}
