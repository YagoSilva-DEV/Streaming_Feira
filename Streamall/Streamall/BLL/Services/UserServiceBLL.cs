using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using Streamall.DAL.Interfaces;
using System;
using Streamall.Exceptions;

namespace Streamall.BLL.Services
{
    internal class UserServiceBLL : IUserBLL
    {
        private readonly IUserDAL _userDAL;
        public UserServiceBLL(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }

        public bool EnterAsClientBLL(UserDTO userDTO)
        {
            User _user = new Client(userDTO.UserName, userDTO.Password, userDTO.Email);

            if(!_userDAL.EnterAsClientDAL(_user))
                throw new InvalidLoginException("Usuário ou senha inválidos.");

            return true;
        }
    }
}
