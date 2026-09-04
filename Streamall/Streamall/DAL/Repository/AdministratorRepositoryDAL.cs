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
                                    nome_usuario, email_usuario, senha_hash_usuario
                                    FROM Tb_Funcionario f INNER JOIN Tb_Usuario u
                                    ON f.pk_fk_id_funcionario = u.pk_id_usuario
                                    WHERE nome_usuario = @nome_usuario AND
                                    senha_hash_usuario = @senha_hash_usuario AND
                                    email_usuario = @email_usuario";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@nome_usuario", user.UserName);
                        cmd.Parameters.AddWithValue("@senha_hash_usuario", user.Password);
                        cmd.Parameters.AddWithValue("@email_usuario", user.Email);
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
