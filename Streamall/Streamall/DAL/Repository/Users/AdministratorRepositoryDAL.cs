using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace Streamall.DAL.Repository
{
    public class AdministratorRepositoryDAL : IAdministratorDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public AdministratorRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }

        public IEnumerable<Client> GetClients()
        {
            List<Client> clients = new List<Client>();
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"SELECT 
                                   pk_fk_id_client,
                                   complete_name_user,
                                   name_user,
                                   status_user
                                   FROM Tb_Client c
                                   INNER JOIN Tb_User u
                                   ON c.pk_fk_id_client = u.pk_id_user
                                   ORDER BY complete_name_user";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_fk_id_client"];
                                string fullName = reader["complete_name_user"].ToString();
                                string userName = reader["name_user"].ToString();
                                bool statusUser = (bool)reader["status_user"];
                                string txtStatusUser = statusUser ? "Ativo" : "Inativo";

                                clients.Add(new Client(id, fullName, userName, txtStatusUser));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou", ex);
            }
            return clients;
        }

        public void RemoveUser(int id)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = "DELETE FROM Tb_User WHERE pk_id_User = @pk_id_User";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@pk_id_User", SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou" + ex.Message);
            }
        }

        public void RemoveClient(int id)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = "DELETE FROM Tb_Client WHERE pk_fk_id_client = @pk_fk_id_client";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@pk_fk_id_client", SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou", ex);
            }
        }

        public void RemoveUserFromTbFav(int id)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = "DELETE FROM Tb_Content_Fav WHERE fk_id_User_content_fav = @fk_id_User_content_fav";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@fk_id_User_content_fav", SqlDbType.Int).Value = id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou", ex);
            }
        }
    }
}
