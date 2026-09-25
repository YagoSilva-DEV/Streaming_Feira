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
using System.Windows;
using System.IO;

namespace Streamall.DAL.Repository
{
    public class UserRepositoryDAL : IUserDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public UserRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }

        public void AddFavoriteContent(int contentId, int userId)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Tb_Content_Fav (fk_id_User_content_fav, fk_id_content_fav)
                                    VALUES(@fk_id_User_content_fav ,@fk_id_content_fav)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@fk_id_User_content_fav", SqlDbType.Int).Value = userId;
                        cmd.Parameters.Add("@fk_id_content_fav", SqlDbType.Int).Value = contentId;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex) when (ex.Number == 2627)
            {
                throw new DataBaseException("Esse filme já foi favoritado.", ex);
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.", ex);
            }
        }

        public IEnumerable<Content> GetFavoriteContents(int userId)
        {
            List<Content> contents = new List<Content>();
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"SELECT 
                                    pk_id_content,
                                    name_content,
                                    path_cover_content
                                    FROM Tb_Content_Fav cf
                                    INNER JOIN Tb_Content c
                                    ON cf.fk_id_content_fav = c.pk_id_content
                                    WHERE cf.fk_id_User_content_fav = @fk_id_User_content_fav";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@fk_id_User_content_fav", SqlDbType.Int).Value = userId;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string name = reader["name_content"].ToString();
                                string pathCover = Path.Combine(AppContext.BaseDirectory ,reader["path_cover_content"].ToString());
                                contents.Add(new Content(id, name, pathCover));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.", ex);
            }
            return contents;
        }

        public void KeepUserActive(int id)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"UPDATE Tb_User
                                 SET
                                 status_user = @status_user
                                 WHERE pk_id_User = @pk_id_User";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@status_user", SqlDbType.Bit).Value = true;
                        cmd.Parameters.Add("@pk_id_User", SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.", ex);
            }
        }

        public void KeepUserInactive(int id)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"UPDATE Tb_User
                                 SET
                                 status_user = @status_user
                                 WHERE pk_id_User = @pk_id_User";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@status_user", SqlDbType.Bit).Value = false;
                        cmd.Parameters.Add("@pk_id_User", SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.", ex);
            }
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

        public void RemoveFavoriteContent(int contentId, int userId)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"DELETE FROM Tb_Content_Fav
                                   WHERE fk_id_User_content_fav = @fk_id_User_content_fav
                                   AND fk_id_content_fav = @fk_id_content_fav";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@fk_id_User_content_fav", SqlDbType.Int).Value = userId;
                        cmd.Parameters.Add("@fk_id_content_fav", SqlDbType.Int).Value = contentId;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.", ex);
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

                    using (SqlDataReader reader = cmd.ExecuteReader())
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
