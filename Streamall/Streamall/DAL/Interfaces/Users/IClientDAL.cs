using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamall.Models.Entities;

namespace Streamall.DAL.Interfaces
{
    public interface IClientDAL
    {
        int SignUpAsUserDAL(User user);
        void SignUpAsClientDAL(int idUser);
    }
}
