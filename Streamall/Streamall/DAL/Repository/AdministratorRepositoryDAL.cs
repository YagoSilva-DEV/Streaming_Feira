using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using Microsoft.Data.SqlClient;

namespace Streamall.DAL.Repository
{
    internal class AdministratorRepositoryDAL : IAdministratorDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public AdministratorRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }
    
    }
}
