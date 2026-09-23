using Streamall.Models.DTO;
using System.Collections.Generic;

namespace Streamall.BLL.Interfaces
{
    public interface IAdministratorBLL
    {
        IEnumerable<ClientDTO> GetClientDTOs();
    }
}
