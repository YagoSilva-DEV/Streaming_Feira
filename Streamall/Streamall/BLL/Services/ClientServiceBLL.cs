using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using Streamall.DAL.Interfaces;
using System;
using Streamall.Exceptions;

namespace Streamall.BLL.Services
{
    internal class ClientServiceBLL : IClientBLL
    {
        private User _user;
        private readonly IClientDAL _clientDAL;
        public ClientServiceBLL(IClientDAL clientDAL)
        {
            _clientDAL = clientDAL;
        }

        public void EnterAsClientBLL(UserDTO userDTO)
        {
            _user = new Client(userDTO.UserName, userDTO.Password, userDTO.Email);

            if(!_clientDAL.EnterAsClientDAL(_user))
                throw new InvalidLoginException("Usuário ou senha inválidos.");
        }
    }
}
