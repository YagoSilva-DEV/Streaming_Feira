using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using Streamall.DAL.Interfaces;
using System;
using Streamall.Exceptions;
using Streamall.Helpers;

namespace Streamall.BLL.Services
{
    internal class ClientServiceBLL : IClientBLL
    {
        private readonly IClientDAL _clientDAL;
        public ClientServiceBLL(IClientDAL clientDAL)
        {
            _clientDAL = clientDAL;
        }

        public void SignUpAsClientBLL(UserDTO userDTO)
        {
            User user = new Client(userDTO.FullName, userDTO.UserName, userDTO.Password, userDTO.Email);
            user.Password = PasswordHelper.HashPassword(userDTO.Password);
            int idUser = _clientDAL.SignUpAsUserDAL(user);

            _clientDAL.SignUpAsClientDAL(idUser);
        }
    }
}
