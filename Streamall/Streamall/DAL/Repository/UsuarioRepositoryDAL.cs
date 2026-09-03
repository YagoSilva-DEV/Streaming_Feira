using Streamall.DAL.Interfaces;
using Streamall.Models.Entities;
using System;
using Microsoft.Data.SqlClient;
using Streamall.Exceptions;

namespace Streamall.DAL.Repository
{
    internal class UsuarioRepositoryDAL : IUsuarioDAL
    {
        private readonly ConexaoDAL _conexaoDAL;

        public UsuarioRepositoryDAL()
        {
            _conexaoDAL = new ConexaoDAL();
        }
        public bool EnterAsClientDAL(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = _conexaoDAL.Conectar())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM Tb_Usuario
                                    WHERE nome_usuario = @nome_usuario AND
                                    email_usuario = @email_usuario AND 
                                    senha_hash_usuario = @senha_hash_usuario";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_usuario", usuario.NomeUsuario);
                        cmd.Parameters.AddWithValue("@email_usuario", usuario.Email);
                        cmd.Parameters.AddWithValue("@senha_hash_usuario", usuario.Senha);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            return reader.HasRows;
                        }
                    }
                }
            }
            catch (SqlException)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.");
            }
        }
    }
}
