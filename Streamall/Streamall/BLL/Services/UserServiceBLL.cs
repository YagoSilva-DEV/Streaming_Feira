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
        public UserServiceBLL(IUserDAL userDal)
        {
            _userDAL = userDal;
        }

        public bool EnterAsClientBLL(UserDTO usuarioDTO)
        {
            User _usario = new Client(usuarioDTO.UserName, usuarioDTO.Password, usuarioDTO.Email);

            if(!_userDAL.EnterAsClientDAL(_usario))
                throw new InvalidLoginException("Usuário ou senha inválidos.");

            return true;
        }
    }
}
