using Streamall.Models.Enums;
using Streamall.Exceptions;

namespace Streamall.Models.Entities
{
    internal abstract class Usuario
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string nomeUsuario, string senha, string email)
        {
            //Construtor para validação de login

            if (string.IsNullOrEmpty(nomeUsuario) && string.IsNullOrEmpty(senha) && string.IsNullOrEmpty(email))
                throw new LoginInvalidoException("Os campos de login não podem estar vazios");
            if (string.IsNullOrWhiteSpace(nomeUsuario))
                throw new LoginInvalidoException("Insira o nome de usuário");
            if (string.IsNullOrWhiteSpace(senha))
                throw new LoginInvalidoException("Insira a senha");
            if (string.IsNullOrWhiteSpace(email))
                throw new LoginInvalidoException("Insira o email");

            NomeUsuario = nomeUsuario;
            Senha = senha;
            Email = email;
        }

        public Usuario(int idUsuario, string nomeCompleto, string nomeUsuario, string senha, string email, TipoUsuario tipoUsuario)
        {
            IdUsuario = idUsuario;
            NomeCompleto = nomeCompleto;
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Email = email;
            TipoUsuario = tipoUsuario;
        }
    }
}
