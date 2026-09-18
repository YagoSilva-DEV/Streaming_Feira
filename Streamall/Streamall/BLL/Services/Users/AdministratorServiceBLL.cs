using Streamall.BLL.Interfaces;
using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using System;

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

    }
}
