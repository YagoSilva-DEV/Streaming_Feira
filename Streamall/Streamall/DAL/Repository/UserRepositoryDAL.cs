using Streamall.DAL.Interfaces;
using Streamall.Models.Entities;
using System;
using Microsoft.Data.SqlClient;
using Streamall.Exceptions;

namespace Streamall.DAL.Repository
{
    internal class UserRepositoryDAL : IUserDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public UserRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }
        public bool EnterAsClientDAL(User user)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"SELECT * FROM Tb_Usuario
                                    WHERE nome_usuario = @nome_usuario AND
                                    email_usuario = @email_usuario AND 
                                    senha_hash_usuario = @senha_hash_usuario";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_usuario", user.UserName);
                        cmd.Parameters.AddWithValue("@email_usuario", user.Email);
                        cmd.Parameters.AddWithValue("@senha_hash_usuario", user.Password);
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
