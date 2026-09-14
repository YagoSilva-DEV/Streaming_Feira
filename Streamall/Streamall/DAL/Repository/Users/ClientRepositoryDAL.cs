using Streamall.DAL.Interfaces;
using Streamall.Models.Entities;
using System;
using Microsoft.Data.SqlClient;
using Streamall.Exceptions;
using System.Data;

namespace Streamall.DAL.Repository
{
    public class ClientRepositoryDAL : IClientDAL
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
                                   (complete_name_user, name_user, password_hash_user, email_user, type_user, status_user)
                                   OUTPUT INSERTED.pk_id_User
                                   VALUES (@complete_name_user, @name_user, @password_hash_user, @email_user, @type_user, @status_user)";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@complete_name_user", SqlDbType.VarChar).Value = user.FullName;
                        cmd.Parameters.Add("@name_user", SqlDbType.VarChar).Value = user.UserName;
                        cmd.Parameters.Add("@password_hash_user", SqlDbType.VarChar).Value = user.Password;
                        cmd.Parameters.Add("@email_user", SqlDbType.VarChar).Value = user.Email;
                        cmd.Parameters.Add("@type_user", SqlDbType.Int).Value = 1;
                        cmd.Parameters.Add("@status_user", SqlDbType.Bit).Value = 0;

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
                        cmd.Parameters.Add("@pk_fk_id_client", SqlDbType.Int).Value = idUser;
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
