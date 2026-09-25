using Streamall.Models.Entities;
using System.Collections.Generic;

namespace Streamall.DAL.Interfaces
{
    public interface IAdministratorDAL
    {
        IEnumerable<Client> GetClients();
        void RemoveUserFromTbFav(int id);
        void RemoveUser(int id);
        void RemoveClient(int id);
    }
}
