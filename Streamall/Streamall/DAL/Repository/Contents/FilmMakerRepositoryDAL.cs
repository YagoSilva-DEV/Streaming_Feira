using Microsoft.Data.SqlClient;
using Streamall.DAL.Interfaces;
using Streamall.Exceptions;
using Streamall.Models.Entities.Contents;
using System.Data;

namespace Streamall.DAL.Repository.Contents
{
    public class FilmMakerRepositoryDAL : IFilmMakerDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public FilmMakerRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }

        public void InsertFilmMaker(FilmMaker filmMaker)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Tb_Filmmaker
                                   (name_filmmaker)
                                   VALUES (@name_filmmaker)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_filmmaker", SqlDbType.VarChar).Value = filmMaker.Name;

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
