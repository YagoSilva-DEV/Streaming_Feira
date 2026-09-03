using Streamall.Models.Enums;

namespace Streamall.Models.Entities
{
    internal class Cliente : Usuario
    {
        public Cliente(string nomeUsuario, string senha, string email) : base(nomeUsuario, senha, email)
        {
        }

        public Cliente(int idUsuario, string nomeCompleto, string nomeUsuario, string senha, string email, TipoUsuario tipoUsuario) : base(idUsuario, nomeCompleto, nomeUsuario, senha, email, tipoUsuario)
        {
        }
    }
}
