using Streamall.BLL.Interfaces;
using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Streamall.Helpers;

namespace Streamall.DAL.Repository
{
    internal class UserRepositoryDAL : IUserDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public UserRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }
        public bool LoginDAL(User user)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"SELECT 
                                    password_hash_user
                                    FROM Tb_User
                                    WHERE name_user = @name_user
                                    AND email_user = @email_user";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name_user", user.UserName);
                        cmd.Parameters.AddWithValue("@email_user", user.Email);
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                                throw new InvalidLoginException("O perfil não foi encontrado");

                            string storedPasswordHash = reader["password_hash_user"].ToString();

                            if (!PasswordHelper.VerifyPassword(user.Password, storedPasswordHash))
                                return false;

                            return true;
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
