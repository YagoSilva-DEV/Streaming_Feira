using Streamall.Models.Enums;
using Streamall.Exceptions;

namespace Streamall.Models.Entities
{
    internal abstract class User
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public UserType TipoUsuario { get; set; }

        public User(string userName, string password, string email)
        {
            //Construtor para validação de login
            if (string.IsNullOrEmpty(userName) && string.IsNullOrEmpty(password) && string.IsNullOrEmpty(email))
                throw new InvalidLoginException("Os campos de login estão vazios");
            if (string.IsNullOrWhiteSpace(userName))
                throw new InvalidLoginException("Insira o nome de usuário");
            if (string.IsNullOrWhiteSpace(email))
                throw new InvalidLoginException("Insira o email");
            if (string.IsNullOrWhiteSpace(password))
                throw new InvalidLoginException("Insira a senha");

            UserName = userName;
            Password = password;
            Email = email;
        }

        public User(int idUsuario, string nomeCompleto, string nomeUsuario, string senha, string email, UserType tipoUsuario)
        {
            UserId = idUsuario;
            FullName = nomeCompleto;
            UserName = nomeUsuario;
            Password = senha;
            Email = email;
            TipoUsuario = tipoUsuario;
        }
    }
}
