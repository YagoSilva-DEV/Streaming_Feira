using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Streamall.Exceptions;

namespace Streamall.DAL.Repository.Contents
{
    public class GenreRepositoryDAL : IGenreDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public GenreRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }

        public void InsertGenre(Genre genre)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Tb_Gender
                                   (name_gender)
                                    VALUES(@name_gender)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_gender", SqlDbType.VarChar).Value = genre.Name;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("A conexão com o banco de dados falhou.", ex);
            }
        }
    }
}
