using Streamall.Models.DTO;

namespace Streamall.BLL.Interfaces
{
    internal interface IClientBLL
    {
        void EnterAsClientBLL(UserDTO userDTO);
        void SignUpAsClientBLL(UserDTO userDTO);
    }
}
