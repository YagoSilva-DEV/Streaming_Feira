using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.DTO
{
    internal class AdministratorDTO : UserDTO
    {
        public AdministratorDTO(string userName, string password, string email) : base(userName, password, email)
        {
        }

        public AdministratorDTO(int userId, string fullName, string userName, string password, string email, UserType userType) : base(userId, fullName, userName, password, email, userType)
        {
        }
    }
}
