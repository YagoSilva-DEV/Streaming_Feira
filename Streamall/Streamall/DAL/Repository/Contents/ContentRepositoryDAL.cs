using Microsoft.Data.SqlClient;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using Streamall.Models.Entities.Contents;
using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;

namespace Streamall.DAL.Repository.Contents
{
    public class ContentRepositoryDAL : IContentDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public ContentRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }
        public IEnumerable<Content> GetContents()
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
                                    synopsis_content,
                                    path_cover_content,
                                    year_realease_content,
                                    type_content,
                                    pk_id_filmmaker,
                                    name_filmmaker,
                                    pk_id_gender,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker
                                    ORDER BY year_realease_content ASC";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int idContent = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                int idFilmMaker = (int)reader["pk_id_filmmaker"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                int idGender = (int)reader["pk_id_gender"];
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(idContent, contentName, synopsis, pathCoverFile, releaseDate, new Genre(idGender, genderName), new FilmMaker(idFilmMaker, filmmakerName), (ContentType)contentType));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }

            return contents;
        }

        public IEnumerable<Genre> GetGenres()
        {
            List<Genre> genres = new List<Genre>();
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = "SELECT pk_id_gender, name_gender FROM Tb_Gender";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_gender"];
                                string name = reader["name_gender"].ToString();

                                genres.Add(new Genre(id, name));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }

            return genres;
        }

        public IEnumerable<FilmMaker> GetFilmMakers()
        {
            List<FilmMaker> filmMakers = new List<FilmMaker>();
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = "SELECT pk_id_filmmaker, name_filmmaker FROM Tb_Filmmaker";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_filmmaker"];
                                string name = reader["name_filmmaker"].ToString();

                                filmMakers.Add(new FilmMaker(id, name));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }

            return filmMakers;
        }

        public void RemoveContent(int id)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = "DELETE FROM Tb_Content WHERE pk_id_content = @pk_id_content";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@pk_id_content", SqlDbType.Int).Value = id;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }
        }

        public void UpdateContent(Content content)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"UPDATE Tb_Content
                                   SET
                                   name_content = @name_content,
                                   synopsis_content = @synopsis_content,
                                   path_cover_content = @path_cover_content,
                                   year_realease_content = @year_realease_content,
                                   fk_id_gender_content = @fk_id_gender_content,
                                   fk_id_filmmaker_content = @fk_id_filmmaker_content
                                   WHERE pk_id_content = @pk_id_content";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_content", SqlDbType.VarChar).Value = content.Name;
                        cmd.Parameters.Add("@synopsis_content", SqlDbType.VarChar).Value = content.Synopsis;
                        cmd.Parameters.Add("@path_cover_content", SqlDbType.VarChar).Value = content.PathCover;
                        cmd.Parameters.Add("@year_realease_content", SqlDbType.DateTime).Value = content.ReleaseDate;
                        cmd.Parameters.Add("@fk_id_gender_content", SqlDbType.Int).Value = content.Genre.Id;
                        cmd.Parameters.Add("@fk_id_filmmaker_content", SqlDbType.Int).Value = content.FilmMaker.Id;
                        cmd.Parameters.Add("@pk_id_content", SqlDbType.Int).Value = content.Id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }
        }


        public void InsertContent(Content content)
        {
            try
            {
                using (SqlConnection conn = _connectionDAL.Connect())
                {
                    conn.Open();
                    string sql = @"INSERT INTO Tb_Content
                                   (name_content, synopsis_content, path_cover_content, year_realease_content, fk_id_gender_content, fk_id_filmmaker_content)
                                   VALUES
                                   (@name_content, @synopsis_content, @path_cover_content, @year_realease_content, @fk_id_gender_content, @fk_id_filmmaker_content)";
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_content", SqlDbType.VarChar).Value = content.Name;
                        cmd.Parameters.Add("@synopsis_content", SqlDbType.VarChar).Value = content.Synopsis;
                        cmd.Parameters.Add("@path_cover_content", SqlDbType.VarChar).Value = content.PathCover;
                        cmd.Parameters.Add("@year_realease_content", SqlDbType.DateTime).Value = content.ReleaseDate;
                        cmd.Parameters.Add("@fk_id_gender_content", SqlDbType.Int).Value = content.Genre.Id;
                        cmd.Parameters.Add("@fk_id_filmmaker_content", SqlDbType.Int).Value = content.FilmMaker.Id;
                        cmd.Parameters.Add("@pk_id_content", SqlDbType.Int).Value = content.Id;

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }
        }
    }
}
