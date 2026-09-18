using Streamall.Models.Entities;

namespace Streamall.DAL.Interfaces
{
    internal interface IAdministratorDAL
    {
        bool EnterAsAdministratorDAL(User user);
    }
}
