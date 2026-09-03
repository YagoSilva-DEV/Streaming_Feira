using Streamall.DAL.Interfaces;
using Streamall.Models.Entities;
using System;
using Microsoft.Data.SqlClient;
using Streamall.Exceptions;

namespace Streamall.DAL.Repository
{
    internal class UserRepositoryDAL : IUserDAL
    {
        private readonly DataBaseConnectionDAL _conexaoDAL;

        public UserRepositoryDAL()
        {
            _conexaoDAL = new DataBaseConnectionDAL();
        }
        public bool EnterAsClientDAL(User usuario)
        {
            try
            {
                using (SqlConnection conn = _conexaoDAL.Connect())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM Tb_Usuario
                                    WHERE nome_usuario = @nome_usuario AND
                                    email_usuario = @email_usuario AND 
                                    senha_hash_usuario = @senha_hash_usuario";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_usuario", usuario.UserName);
                        cmd.Parameters.AddWithValue("@email_usuario", usuario.Email);
                        cmd.Parameters.AddWithValue("@senha_hash_usuario", usuario.Password);
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
