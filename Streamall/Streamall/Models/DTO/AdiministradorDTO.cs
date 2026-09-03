using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.DTO
{
    internal class AdiministradorDTO : UsuarioDTO
    {
        public AdiministradorDTO(string nomeUsuario, string senha, string email) : base(nomeUsuario, senha, email)
        {
        }

        public AdiministradorDTO(int idUsuario, string nomeCompleto, string nomeUsuario, string senha, string email, TipoUsuario tipoUsuario) : base(idUsuario, nomeCompleto, nomeUsuario, senha, email, tipoUsuario)
        {
        }
    }
}
