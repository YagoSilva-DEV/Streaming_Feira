using Streamall.BLL.Interfaces;
using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamall.BLL.Services
{
    public class AdministratorServiceBLL : IAdministratorBLL
    {
        private User _user;
        private readonly IAdministratorDAL _adminDAL;

        public AdministratorServiceBLL(IAdministratorDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public IEnumerable<ClientDTO> GetClientDTOs()
        {
            return _adminDAL.GetClients().Select(c => new ClientDTO(c));
        }

        public void RemoveClient(int id)
        {
            _adminDAL.RemoveUserFromTbFav(id);
            _adminDAL.RemoveClient(id);
            _adminDAL.RemoveUser(id);
        }
    }
}
