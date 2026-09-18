using Streamall.Models.Enums;

namespace Streamall.Models.Entities
{
    public class Client : User
    {
        public Client(string userName, string password, string email) : base(userName, password, email)
        {
        }

        public Client(string fullName, string userName, string password, string email) : base(fullName, userName, password, email)
        {
        }

        public Client(int userId, string fullName, string userName, string password, string email, UserType userType) : base(userId, fullName, userName, password, email, userType)
        {
        }
    }
}
