using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.DAL.Interfaces
{
    internal interface IUserDAL
    {
        bool LoginDAL(User user);
    }
}
