using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamall.Models.Enums;

namespace Streamall.Models.DTO
{
    internal abstract class UserDTO
    {
        public int UserId { get; set; }
        public string NomeCompleto { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }

        public UserDTO(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public UserDTO(int userId, string nomeCompleto, string userName, string password, string email, UserType userType)
        {
            UserId = userId;
            NomeCompleto = nomeCompleto;
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
        }
    }
}
