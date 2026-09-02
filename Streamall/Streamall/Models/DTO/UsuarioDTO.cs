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
        public string NomeCompleto { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public TipoUsuario TipoUsuario { get; set; }

    }
}
