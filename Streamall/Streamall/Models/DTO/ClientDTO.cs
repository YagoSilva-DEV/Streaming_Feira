using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.Models.DTO
{
    internal class ClientDTO : UserDTO
    {
        public ClientDTO(string nomeUsuario, string senha, string email) : base(nomeUsuario, senha, email)
        {
        }

        public ClientDTO(int idUsuario, string nomeCompleto, string nomeUsuario, string senha, string email, UserType tipoUsuario) : base(idUsuario, nomeCompleto, nomeUsuario, senha, email, tipoUsuario)
        {
        }
    }
}
