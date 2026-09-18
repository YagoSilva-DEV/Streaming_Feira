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
using System.Data;
using Streamall.Models.Enums;

namespace Streamall.DAL.Repository
{
    public class UserRepositoryDAL : IUserDAL
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
                        cmd.Parameters.Add("@name_user", SqlDbType.VarChar).Value = user.UserName;
                        cmd.Parameters.Add("@email_user", SqlDbType.VarChar).Value = user.Email;
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

        public User UserData(string userName)
        {
            using (SqlConnection conn = _connectionDAL.Connect())
            {
                conn.Open();

                string sql = @"SELECT pk_id_User, complete_name_user, password_hash_user, email_user, type_user
                               FROM Tb_User WHERE name_user = @name_user";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.Add("@name_user", SqlDbType.VarChar).Value = userName;

                    using(SqlDataReader reader = cmd.ExecuteReader())
                    {
                        reader.Read();

                        int id = (int)reader["pk_id_User"];
                        string fullName = (string)reader["complete_name_user"];
                        string storedHashPassword = (string)reader["password_hash_user"];
                        string email = (string)reader["email_user"];
                        int typeUser = (int)reader["type_user"];

                        return new User(id, fullName, userName, storedHashPassword, email, (UserType)typeUser);
                    }
                }
            }
        }
    }
}
