using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamall.Models.Enums;
using Streamall.Models.Entities;

namespace Streamall.Models.DTO
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public string StatusUser { get; set; }

        public UserDTO(string userName, string password, string email)
        {
            UserName = userName;
            Password = password;
            Email = email;
        }

        public UserDTO(int id, string fullName, string userName, string statusUser)
        {
            UserId = id;
            FullName = fullName;
            UserName = userName;
            StatusUser = statusUser;
        }

        public UserDTO(string fullName, string userName, string password, string email)
        {
            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
        }

        public UserDTO(int userId, string fullName, string userName, string password, string email, UserType userType)
        {
            UserId = userId;
            FullName = fullName;
            UserName = userName;
            Password = password;
            Email = email;
            UserType = userType;
        }

        public UserDTO(User user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));

            UserId = user.UserId;
            FullName = user.FullName;
            UserName = user.UserName;
            Password = user.Password;
            Email = user.Email;
            UserType = user.UserType;
            StatusUser = user.StatusUser;
        }
    }
}
