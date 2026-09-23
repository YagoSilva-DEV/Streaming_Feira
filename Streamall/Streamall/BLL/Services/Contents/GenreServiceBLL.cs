using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces.Contents;
using Streamall.Models.DTO.ContentsDTO;
using Streamall.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.BLL.Services.Contents
{
    public class GenreServiceBLL : IGenreBLL
    {
        private readonly IGenreDAL _genreDAL;

        public GenreServiceBLL (IGenreDAL genreDAL)
        {
            _genreDAL = genreDAL;
        } 
        public void InsertGenre(GenreDTO genreDTO)
        {
            Genre genre = new Genre(genreDTO.Name);

            _genreDAL.InsertGenre(genre);
        }
    }
}
