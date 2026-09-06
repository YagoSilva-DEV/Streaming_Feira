using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using Microsoft.Data.SqlClient;

namespace Streamall.DAL.Repository
{
    internal class AdministratorRepositoryDAL : IAdministratorDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public AdministratorRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }

        public bool EnterAsAdministratorDAL(User user)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"SELECT 
                                    name_user, email_user, password_hash_user
                                    FROM Tb_Administrator a INNER JOIN Tb_User u
                                    ON a.pk_fk_id_administrator = u.pk_id_user
                                    WHERE name_user = @name_user AND
                                    password_hash_user = @password_hash_user AND
                                    email_user = @email_user";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@name_user", user.UserName);
                        cmd.Parameters.AddWithValue("@password_hash_user", user.Password);
                        cmd.Parameters.AddWithValue("@email_user", user.Email);
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
