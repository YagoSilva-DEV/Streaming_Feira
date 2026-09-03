using Streamall.Models.DTO;

namespace Streamall.BLL.Interfaces
{
    internal interface IUserBLL
    {
        bool EnterAsClientBLL(UserDTO usuarioDTO);
    }
}
