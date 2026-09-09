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
        public int SignUpAsUserDAL(User user)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();

                    string sql = @"INSERT INTO Tb_User
                                   (complete_name_user, name_user, password_hash_user, email_user, type_user)
                                   OUTPUT INSERTED.pk_id_User
                                   VALUES (@complete_name_user, @name_user, @password_hash_user, @email_user, @type_user)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@complete_name_user", user.FullName);
                        cmd.Parameters.AddWithValue("@name_user", user.UserName);
                        cmd.Parameters.AddWithValue("@password_hash_user", user.Password);
                        cmd.Parameters.AddWithValue("@email_user", user.Email);
                        cmd.Parameters.AddWithValue("@type_user", 1);

                        return (int)cmd.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                throw new InvalidSignUpException("Este nome de usuário já existe.");
            }
            catch (SqlException)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.");
            }
        }

        public void SignUpAsClientDAL(int idUser)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Tb_Client
                               (pk_fk_id_client)
                                VALUES(@pk_fk_id_client)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@pk_fk_id_client", idUser);
                        cmd.ExecuteNonQuery();
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
