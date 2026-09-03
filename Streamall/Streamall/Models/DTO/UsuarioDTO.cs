using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Streamall.Models.Enums;

namespace Streamall.Models.DTO
{
    internal abstract class UsuarioDTO
    {
        public int IdUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

        public UsuarioDTO(string nomeUsuario, string senha, string email)
        {
            NomeUsuario = nomeUsuario;
            Senha = senha;
            Email = email;
        }

        public UsuarioDTO(int idUsuario, string nomeCompleto, string nomeUsuario, string senha, string email, TipoUsuario tipoUsuario)
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
