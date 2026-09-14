using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.Entities
{
    public class Administrator : User
    {
        public Administrator(string userName, string password, string email) : base(userName, password, email)
        {
        }

        public Administrator(int userId, string fullName, string userName, string password, string email, UserType userType) : base(userId, fullName, userName, password, email, userType)
        {
        }
    }
}
