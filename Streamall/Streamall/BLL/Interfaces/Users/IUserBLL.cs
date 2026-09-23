using Streamall.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.BLL.Interfaces
{
    public interface IUserBLL
    {
        UserDTO LoginBLL(UserDTO userDTO);
        void KeepUserActive(int id);
        void KeepUserInactive(int id);
    }
}
