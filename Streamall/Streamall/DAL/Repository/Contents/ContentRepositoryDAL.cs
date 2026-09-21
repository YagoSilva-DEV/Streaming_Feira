using Microsoft.Data.SqlClient;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Exceptions;
using Streamall.Models.Entities;
using Streamall.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace Streamall.DAL.Repository.Contents
{
    public class ContentRepositoryDAL : IContentDAL
    {
        private readonly DataBaseConnectionDAL _connectionDAL;

        public ContentRepositoryDAL()
        {
            _connectionDAL = new DataBaseConnectionDAL();
        }

        public IEnumerable<Content> GetActionContens()
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker
                                      
                                    WHERE name_gender = @name_gender
                                      ";
                    

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_gender", SqlDbType.VarChar).Value="Ação";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
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

        public IEnumerable<Content> GetAnimationContens()
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker
                                      
                                    WHERE name_gender = @name_gender
                                      ";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_gender", SqlDbType.VarChar).Value = "Animação";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker";

                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex){
                throw new DataBaseException("Erro ao acessar o banco de dados: ", ex);
            }
            
            return contents;
        }

        public IEnumerable<Content> GetDocumentaryContens()
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker
                                      
                                    WHERE name_gender = @name_gender
                                      ";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_gender", SqlDbType.VarChar).Value = "Documentário";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
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

        public IEnumerable<Content> GetDramaContens()
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker
                                      
                                    WHERE name_gender = @name_gender
                                      ";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_gender", SqlDbType.VarChar).Value = "Drama";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
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

        public IEnumerable<Content> GetRecomendationContens()
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
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

        public IEnumerable<Content> GetScienceFictionContens()
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
                                    name_filmmaker,
                                    name_gender
                                    FROM Tb_Content c
                                    INNER JOIN Tb_Gender g
                                    ON c.fk_id_Gender_content = g.pk_id_gender
                                    INNER JOIN Tb_Filmmaker f
                                    ON c.fk_id_filmmaker_content = f.pk_id_filmmaker
                                      
                                    WHERE name_gender = @name_gender
                                      ";


                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        cmd.Parameters.Add("@name_gender", SqlDbType.VarChar).Value = "Ficção Científica";
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = (int)reader["pk_id_content"];
                                string contentName = reader["name_content"].ToString();
                                string synopsis = reader["synopsis_content"].ToString();
                                string pathCoverFile = Path.Combine(AppContext.BaseDirectory, reader["path_cover_content"].ToString());
                                DateTime releaseDate = (DateTime)reader["year_realease_content"];
                                int contentType = (int)reader["type_content"];
                                string filmmakerName = reader["name_filmmaker"].ToString();
                                string genderName = reader["name_gender"].ToString();

                                contents.Add(new Content(id, contentName, synopsis, pathCoverFile, releaseDate, genderName, filmmakerName, (ContentType)contentType));
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
    }
}
