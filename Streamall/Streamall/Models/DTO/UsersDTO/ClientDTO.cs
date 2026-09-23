using Streamall.Models.Enums;
using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.DTO
{
    public class ClientDTO : UserDTO
    {
        public ClientDTO(string userName, string password, string email) : base(userName, password, email)
        {
        }

        public ClientDTO(int id, string fullName, string userName, bool statusUser) : base(id, fullName, userName, statusUser)
        { }

        public ClientDTO(string fullName, string userName, string password, string email) : base(fullName, userName, password, email)
        {
        }

        public ClientDTO(int userId, string fullName, string userName, string password, string email, UserType userType) : base(userId, fullName, userName, password, email, userType)
        {
        }

        public ClientDTO(Client client) : base(client)
        {
        }
    }
}
