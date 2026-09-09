using Streamall.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.BLL.Interfaces
{
    internal interface IUserBLL
    {
        void LoginBLL(UserDTO userDTO);
    }
}
