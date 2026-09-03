using Streamall.BLL.Interfaces;
using Streamall.Models.DTO;
using Streamall.Models.Entities;
using Streamall.DAL.Interfaces;
using System;
using Streamall.Exceptions;

namespace Streamall.BLL.Services
{
    internal class UsuarioServiceBLL : IUsuarioBLL
    {
        private readonly IUsuarioDAL _usuarioDAL;
        public UsuarioServiceBLL(IUsuarioDAL usuarioDAL)
        {
            _usuarioDAL = usuarioDAL;
        }

        public bool EnterAsClientBLL(UsuarioDTO usuarioDTO)
        {
            Usuario _usario = new Cliente(usuarioDTO.NomeUsuario, usuarioDTO.Senha, usuarioDTO.Email);

            if(!_usuarioDAL.EnterAsClientDAL(_usario))
                throw new LoginInvalidoException("Usuário ou senha inválidos.");

            return true;
        }
    }
}
