using Streamall.Models.Entities.Contents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Streamall.DAL.Interfaces
{
    public interface IFilmMakerDAL
    {
        void InsertFilmMaker(FilmMaker filmMaker);
    }
}
