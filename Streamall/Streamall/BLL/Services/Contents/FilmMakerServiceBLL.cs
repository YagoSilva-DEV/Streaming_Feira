using Streamall.BLL.Interfaces.Contents;
using Streamall.DAL.Interfaces;
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
    public class FilmMakerServiceBLL : IFilmMakerBLL
    {
        private readonly IFilmMakerDAL _filmMakerDAL;

        public FilmMakerServiceBLL(IFilmMakerDAL filmMakerDAL)
        {
            _filmMakerDAL = filmMakerDAL;
        }
        public void InsertFilmMaker(FilmMakerDTO filmMakerDTO)
        {
            FilmMaker filmMaker = new FilmMaker(filmMakerDTO.Name);

            _filmMakerDAL.InsertFilmMaker(filmMaker);
        }
    }
}
