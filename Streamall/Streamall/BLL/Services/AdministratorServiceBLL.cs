using Streamall.BLL.Interfaces;
using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System;

namespace Streamall.BLL.Services
{
    internal class AdministratorServiceBLL : IAdministratorBLL
    {
        private User _user;
        private readonly IAdministratorDAL _adminDAL;

        public AdministratorServiceBLL(IAdministratorDAL adminDAL)
        {
            _adminDAL = adminDAL;
        }

        public void EnterAsAdministratorBLL(UserDTO admin)
        {
            _user = new Administrator(admin.UserName, admin.Password, admin.Email);

            if (!_adminDAL.EnterAsAdministratorDAL(_user))
                throw new InvalidLoginException("Usuário ou senha inválidos");
        }
    }
}
