using Streamall.DAL.Interfaces;
using Streamall.Models.Entities;
using System;
using Microsoft.Data.SqlClient;
using Streamall.Exceptions;

namespace Streamall.DAL.Repository
{
    internal class ClientRepositoryDAL : IClientDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public ClientRepositoryDAL()
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
                    string sql = @"SELECT name_user, email_user, password_hash_user
                                    FROM Tb_Client c
                                    INNER JOIN Tb_User u
                                    ON c.pk_fk_id_client = u.pk_id_user
                                    WHERE name_user = @name_user AND
                                    email_user = @email_user AND 
                                    password_hash_user = @password_hash_user";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name_user", user.UserName);
                        cmd.Parameters.AddWithValue("@email_user", user.Email);
                        cmd.Parameters.AddWithValue("@password_hash_user", user.Password);
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
