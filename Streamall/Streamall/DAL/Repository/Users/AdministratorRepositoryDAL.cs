using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

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
                                   pk_fk_id_user,
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
                                int id = (int)reader["pk_fk_id_user"];
                                string fullName = reader["complete_name_user"].ToString();
                                string userName = reader["name_user"].ToString();
                                bool statusUser = (bool)reader["status_user"];

                                clients.Add(new Client(id, fullName, userName, statusUser));
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
    }
}
