using Streamall.Models.Enums;

namespace Streamall.Models.Entities
{
    internal class Client : User
    {
        public Client(string userName, string password, string email) : base(userName, password, email)
        {
        }

        public Client(int userId, string fullName, string userName, string password, string email, UserType tipoUsuario) : base(userId, fullName, userName, password, email, tipoUsuario)
        {
        }
    }
}
